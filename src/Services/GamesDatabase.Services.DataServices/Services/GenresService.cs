using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDatabase.Data.Common.Repositories;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamesDatabase.Services.DataServices.Services
{
    public class GenresService : IGenresService
    {
        private readonly IDeletableEntityRepository<Genre> genresRepository;

        public GenresService(IDeletableEntityRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public TViewModel GetGenreById<TViewModel>(int id)
        {
            return genresRepository.All()
                                   .Where(x => x.Id == id)
                                   .To<TViewModel>()
                                   .SingleOrDefault();
        }

        public IEnumerable<TViewModel> GetAllGenres<TViewModel>()
        {
            return genresRepository.All().To<TViewModel>();
        }

        public async Task<int> Create(GenreInputModel input)
        {
            var genre = new Genre()
            {
                Description = input.Description,
                Name = input.Name,
            };

            await genresRepository.AddAsync(genre);
            await genresRepository.SaveChangesAsync();

            return genre.Id;
        }

        public int GetCount()
        {
            return genresRepository.All().Count();
        }

        public IEnumerable<SelectListItem> GetAllGenresAsOptions()
        {
            return genresRepository.All().Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }
    }
}
