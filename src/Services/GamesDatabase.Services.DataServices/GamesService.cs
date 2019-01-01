using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesDatabase.Services.ViewModels;

namespace GamesDatabase.Services.DataServices
{
    public class GamesService
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Genre> genresRepository;

        public GamesService(
            IRepository<Game> gamesRepository,
            IRepository<Genre> genresRepository)
        {
            this.gamesRepository = gamesRepository;
            this.genresRepository = genresRepository;
        }

        //public IEnumerable<IndexJokeViewModel> GetRandomJokes(int count)
        //{
        //    var jokes = this.gamesRepository.All()
        //        .OrderBy(x => Guid.NewGuid())
        //        .To<IndexJokeViewModel>().Take(count).ToList();

        //    return jokes;
        //}

        public int GetCount()
        {
            return this.gamesRepository.All().Count();
        }

        //public async Task<int> Create(int categoryId, string content)
        //{
        //    var game = new Game
        //    {
        //        CategoryId = categoryId,
        //        Content = content,
        //    };

        //    await this.gamesRepository.AddAsync(game);
        //    await this.gamesRepository.SaveChangesAsync();

        //    return game.Id;
        //}


        // This should return a TViewModel, NOT Game
        // The .To<TViewModel>() is not a recognized method
        public Game GetGameById<TViewModel>(int id)
        {
            var game = this.gamesRepository.All().Where(x => x.Id == id)
                .SingleOrDefault();
            return game;
        }

        //public IEnumerable<JokeSimpleViewModel> GetAllByCategory(int categoryId)
        //    => this.gamesRepository
        //            .All()
        //            .Where(j => j.CategoryId == categoryId)
        //            .To<JokeSimpleViewModel>();

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
