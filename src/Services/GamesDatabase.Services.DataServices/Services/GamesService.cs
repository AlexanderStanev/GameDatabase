using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDatabase.Data.Core.Repositories;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;

namespace GamesDatabase.Services.DataServices.Services
{
    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IGenresService genresService;
        private readonly IImageService imageService;

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

        public IEnumerable<TViewModel> GetRandom<TViewModel>(int count)
        {
            return gamesRepository.AllAsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .To<TViewModel>()
                .Take(count)
                .ToList();
        }

        public IEnumerable<TViewModel> GetLatestReleased<TViewModel>(int count)
        {
            return gamesRepository.AllAsNoTracking()
                //.OrderByDescending(x => x.Released)
                .Take(count)
                .To<TViewModel>()
                .ToList();
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(string title, int[] genreIds, int page, int itemsPerPage)
        {
            var games = gamesRepository.AllAsNoTracking();
            if (genreIds != null)
            {
                foreach (var genreId in genreIds)
                {
                    games = games.Where(x => x.GameGenre.Select(x => x.GenreId).Contains(genreId));
                }
            }

            if (title != null)
            {
                games = games.Where(x => x.Title.Contains(title));
            }

            return games.OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<TViewModel>()
                .ToList();
        }

        public int GetCount()
        {
            return gamesRepository.AllAsNoTracking().Count();
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

            gamesRepository.Update(game);
            await gamesRepository.SaveChangesAsync();

            // TODO: Fix Update of Genres
            //await genresService.RelateGameWithGenres(game.Id, input.GenreIds);
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
            await gamesRepository.SaveChangesAsync();
        }
    }
}
