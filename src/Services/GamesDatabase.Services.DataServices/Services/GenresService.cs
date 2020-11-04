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
    public class GenresService : IGenresService
    {
        private readonly IRepository<Genre> genresRepository;

        public GenresService(IRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public TViewModel GetGenreById<TViewModel>(string id)
        {
            return genresRepository.All()
                .Where(x => x.Id == id)
                .To<TViewModel>()
                .SingleOrDefault();
        }

        public IEnumerable<GenreViewModel> GetAllGenres()
        {
            return genresRepository.All()
                .To<GenreViewModel>();
        }

        public async Task<string> Create(GenreInputModel input)
        {
            var genre = new Genre()
            {
                Description = input.Description,
                Name = input.Name
            };

            await genresRepository.AddAsync(genre);
            await genresRepository.SaveChangesAsync();

            return genre.Id;
        }

        public bool IsGenreIdValid(string genreId)
        {
            return this.genresRepository.All().Any(x => x.Id == genreId);
        }

        public int GetCount()
        {
            return genresRepository.All()
                .Count();
        }
    }
}
