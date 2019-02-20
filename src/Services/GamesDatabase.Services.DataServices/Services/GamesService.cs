using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Services.Models.InputModels;
using GamesDatabase.Services.Models.ViewModels;

namespace GamesDatabase.Services.DataServices.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IGenresService genresService;

        public GamesService(
            IRepository<Game> gamesRepository,
            IGenresService genresService)

        {
            this.gamesRepository = gamesRepository;
            this.genresService = genresService;
        }

        public IEnumerable<DetailedGameViewModel> GetRandomGames(int count)
        {
            var games = gamesRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .To<DetailedGameViewModel>()
                .Take(count)
                .ToList();

            return games;
        }

        public IEnumerable<DetailedGameViewModel> GetAllGamesByGenreId(int id)
        {
            return gamesRepository.All()
                .Where(x => x.GenreId == id)
                .To<DetailedGameViewModel>();
        }

        public IEnumerable<DetailedGameViewModel> GetLatestReleasedGames(int count)
        {
            return gamesRepository.All()
                .OrderByDescending(x => x.DateReleased)
                .Take(count)
                .To<DetailedGameViewModel>();
        }

        public IEnumerable<DetailedGameViewModel> GetAllGames()
        {
            return gamesRepository.All()
                .To<DetailedGameViewModel>();
        }

        public int GetCount()
        {
            return gamesRepository.All().Count();
        }

        public async Task<int> Create(GameInputModel input)
        {
            var game = new Game()
            {
                Title = input.Title,
                DateReleased = input.DateReleased,
                Description = input.Description,
                Developer = input.Developer,
                GenreId = int.Parse(input.GenreId)
            };

            await gamesRepository.AddAsync(game);
            await gamesRepository.SaveChangesAsync();

            return game.Id;
        }

        public TViewModel GetGameById<TViewModel>(int id)
        {
            var game = this.gamesRepository.All()
                .Where(x => x.Id == id)
                .To<TViewModel>()
                .SingleOrDefault();

            return game;
        }
    }
}
