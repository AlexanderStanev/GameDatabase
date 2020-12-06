using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameDatabase.Data.Common.Repositories;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GamesDatabase.Services.DataServices.Services
{
    public class GamesService : IGamesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IGenresService genresService;

        public GamesService(IDeletableEntityRepository<Game> gamesRepository,
            IGenresService genresService)

        {
            this.gamesRepository = gamesRepository;
            this.genresService = genresService;
        }

        public TViewModel GetGameById<TViewModel>(int id)
        {
            var game = this.gamesRepository.AllAsNoTracking()
                                           .Where(x => x.Id == id)
                                           .To<TViewModel>()
                                           .SingleOrDefault();
            return game;
        }

        public IEnumerable<TViewModel> GetRandomGames<TViewModel>(int count)
        {
            var games = gamesRepository.AllAsNoTracking()
                                       .OrderBy(x => Guid.NewGuid())
                                       .To<TViewModel>()
                                       .Take(count)
                                       .ToList();
            return games;
        }

        public IEnumerable<TViewModel> GetAllGamesByGenreId<TViewModel>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetLatestReleasedGames<TViewModel>(int count)
        {
            return gamesRepository.AllAsNoTracking()
                                  //.OrderByDescending(x => x.Releases)
                                  .Take(count)
                                  .To<TViewModel>();
        }

        public IEnumerable<TViewModel> GetAllGames<TViewModel>(int page, int itemsPerPage = 12)
        {
            return gamesRepository.AllAsNoTracking()
                                  .OrderByDescending(x => x.Id)
                                  .Skip((page - 1) * itemsPerPage)
                                  .Take(itemsPerPage)
                                  .To<TViewModel>();
        }

        public int GetCount()
        {
            return gamesRepository.AllAsNoTracking()
                                  .Count();
        }

        public async Task<int> Create(GameInputModel input, string rootPath)
        {
            var game = AutoMapperConfig.MapperInstance.Map<Game>(input);

            await gamesRepository.AddAsync(game);
            await gamesRepository.SaveChangesAsync();

            if (input.MediaFiles.Any())
            {
                // TODO: Implement uploading of videos as well
                game.Images = await SaveImageFiles(input.MediaFiles, game.Id, rootPath);
                await gamesRepository.SaveChangesAsync();
            }

            return game.Id;
        }

        private async Task<List<Image>> SaveImageFiles(IEnumerable<IFormFile> mediaFiles, int gameId, string rootPath)
        {
            var images = new List<Image>();

            var commonPath = $"/images/games/{gameId}";
            var directoryPath = $"{rootPath}/{commonPath}";
            Directory.CreateDirectory(directoryPath);

            var firstImage = true;
            foreach (var image in mediaFiles)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new FormatException($"The extension - {extension} is not accepted");
                }

                var dbImage = new Image()
                {
                    GameId = gameId,
                };

                // TODO: Implement better image type logic
                if (firstImage)
                {
                    dbImage.ImageType = ImageType.Cover;
                    firstImage = false;
                }
                else
                {
                    dbImage.ImageType = ImageType.Normal;
                }

                dbImage.Path = $"{commonPath}/{dbImage.Id}.{extension}";
                images.Add(dbImage);

                var fullPath = rootPath + dbImage.Path;
                using Stream fileStream = new FileStream(fullPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            return images;
        }

        public async Task<int> Update(GameInputModel input)
        {
            var game = gamesRepository.AllWithDeleted().FirstOrDefault(x => x.Id == input.Id);
            if (game == null)
            {
                throw new InvalidOperationException("The game could not be found");
            }

            game.Description = input.Description;
            game.Title = input.Title;
            game.OfficialWebsite = input.OfficialWebsite;

            var id = game.Id;

            await gamesRepository.SaveChangesAsync();
            return input.Id;
        }

        public async Task Delete(int id)
        {
            var game = await gamesRepository.GetByIdWithDeletedAsync(id);
            if (game == null)
            {
                throw new InvalidOperationException("The game could not be found");
            }

            gamesRepository.Delete(game);
        }
    }
}
