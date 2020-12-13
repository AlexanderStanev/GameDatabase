using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameDatabase.Data.Core.Repositories;
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
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IGenresService genresService;
        private readonly IImageService imageService;
        //private readonly GamesDatabaseContext

        public GamesService(IDeletableEntityRepository<Game> gamesRepository,
            IGenresService genresService,
            IImageService imageService)

        {
            this.gamesRepository = gamesRepository;
            this.genresService = genresService;
            this.imageService = imageService;
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

            await genresService.RelateGameWithGenres(game.Id, input.GenreIds);

            if (input.MediaFiles.Any())
            {
                // TODO: Implement uploading of videos as well
                game.Images = await imageService.SaveImageFiles(input.MediaFiles, game.Id, rootPath);
                await gamesRepository.SaveChangesAsync();
            }

            return game.Id;
        }

        public async Task<int> Update(GameInputModel input)
        {
            var game = gamesRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(x => x.Id == input.Id);
            if (game == null)
            {
                throw new InvalidOperationException("The game could not be found");
            }

            game = AutoMapperConfig.MapperInstance.Map<Game>(input);



            await genresService.RelateGameWithGenres(game.Id, input.GenreIds);
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
