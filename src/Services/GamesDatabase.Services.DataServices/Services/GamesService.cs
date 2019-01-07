using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Services.Models.InputModels;
using GamesDatabase.Services.Models.ViewModels.Game;

namespace GamesDatabase.Services.DataServices.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<Game> gamesRepository;

        public GamesService(
            IRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        public IEnumerable<GameDetailsViewModel> GetRandomGames(int count)
        {
            var games = this.gamesRepository.All()
                    .OrderBy(x => Guid.NewGuid())
                    .To<GameDetailsViewModel>()
                    .Take(count)
                    .ToList();

            return games;
        }

        public IEnumerable<GameDetailsViewModel> GetAllGamesByGenreId(int id)
        {
            return gamesRepository.All()
                .Where(x=>x.Genres.Any(y=>y.Id == id))
                .To<GameDetailsViewModel>();
        }

        public IEnumerable<GameDetailsViewModel> GetLatestReleasedGames(int count)
        {
            return gamesRepository.All()
                                  .OrderBy(x => x.DateReleased)
                                  .Take(count)
                                  .To<GameDetailsViewModel>();
        }

        public IEnumerable<GameDetailsViewModel> GetAllGames()
        {
            return gamesRepository.All().To<GameDetailsViewModel>();
        }

        public int GetCount()
        {
            return gamesRepository.All().Count();
        }

        public async Task<int> Create(GameInputModel input)
        {
            var game = AutoMapper.Mapper.Map<Game>(input);

            await gamesRepository.AddAsync(game);
            await gamesRepository.SaveChangesAsync();

            return game.Id;
        }

        public TViewModel GetGameById<TViewModel>(int id)
        {
            var game = this.gamesRepository.All().Where(x => x.Id == id).To<TViewModel>().SingleOrDefault();
            return game;
        }

        //public bool AddRatingToJoke(int jokeId, int rating)
        //{
        //    var joke = this.gamesRepository.All().FirstOrDefault(j => j.Id == jokeId);
        //    if (joke != null)
        //    {
        //        joke.Rating += rating;
        //        this.gamesRepository.SaveChangesAsync();
        //        return true;
        //    }

        //    return false;
        //}
    }
}
