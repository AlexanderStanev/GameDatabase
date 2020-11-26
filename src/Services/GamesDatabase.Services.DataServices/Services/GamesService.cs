using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;

namespace GamesDatabase.Services.DataServices.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IGenresService genresService;

        public GamesService(
            IRepository<Game> gamesRepository)
            //,IGenresService genresService)

        {
            this.gamesRepository = gamesRepository;
            //this.genresService = genresService;
        }

        public IEnumerable<TViewModel> GetRandomGames<TViewModel>(int count)
        {
            var games = gamesRepository.All()
                                       .OrderBy(x => Guid.NewGuid())
                                       .To<TViewModel>()
                                       .Take(count)
                                       .ToList();

            return games;
        }

        public IEnumerable<TViewModel> GetAllGamesByGenreId<TViewModel>(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetLatestReleasedGames<TViewModel>(int count)
        {
            return gamesRepository.All()
                                  //.OrderByDescending(x => x.Releases)
                                  .Take(count)
                                  .To<TViewModel>();
        }

        public IEnumerable<TViewModel> GetAllGames<TViewModel>()
        {
            return gamesRepository.All()
                .To<TViewModel>();
        }

        public int GetCount()
        {
            return gamesRepository.All()
                                  .Count();
        }

        public async Task<string> Create(GameInputModel input)
        {
            var game = new Game()
            {
                Title = input.Title,

            };

            await gamesRepository.AddAsync(game);
            await gamesRepository.SaveChangesAsync();

            return game.Id;
        }

        public TViewModel GetGameById<TViewModel>(string id)
        {
            var game = this.gamesRepository.All()
                                           .Where(x => x.Id == id)
                                           .To<TViewModel>()
                                           .SingleOrDefault();

            return game;
        }
    }
}
