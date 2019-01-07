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
    public class GenresService : IGenresService
    {
        private readonly IRepository<Genre> genresRepository;

        public GenresService(IRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public TViewModel GetGenreById<TViewModel>(int id)
        {
            return genresRepository.All().Where(x => x.Id == id).To<TViewModel>().SingleOrDefault();
        }

        public IEnumerable<GameDetailsViewModel> GetAllGenres()
        {
            return genresRepository.All().To<GameDetailsViewModel>();
        }

        public async Task<int> Create(GenreInputModel input)
        { 
            var genre = AutoMapper.Mapper.Map<Genre>(input);

            await genresRepository.AddAsync(genre);
            await genresRepository.SaveChangesAsync();

            return genre.Id;
        }

        public int GetCount()
        {
            return genresRepository.All().Count();
        }
    }
}
