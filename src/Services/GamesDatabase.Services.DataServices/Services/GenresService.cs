using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDatabase.Data.Core.Repositories;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;
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

        public async Task<int> Update(GenreInputModel input)
        {
            var genre = genresRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(x => x.Id == input.Id);
            if (genre == null)
            {
                throw new InvalidOperationException("The genre could not be found");
            }

            genre = AutoMapperConfig.MapperInstance.Map<Genre>(input);

            genresRepository.Update(genre);
            await genresRepository.SaveChangesAsync();

            return input.Id;
        }

        public async Task Delete(int id)
        {
            var genre = await genresRepository.GetByIdWithDeletedAsync(id);
            if (genre == null)
            {
                throw new InvalidOperationException("The genre could not be found");
            }

            genresRepository.Delete(genre);
            await genresRepository.SaveChangesAsync();
        }

        public int GetCount()
        {
            return genresRepository.All().Count();
        }

        public IEnumerable<SelectListItem> GetAllGenresAsOptions(int[] selectedIds)
        {
            return genresRepository.All()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString(), selectedIds != null && selectedIds.Contains(x.Id)))
                .ToList();
        }

        public async Task RelateGameWithGenres(int gameId, int[] genreIds)
        {
            var genres = genresRepository.All()
                .Where(x => genreIds.Contains(x.Id))
                .ToList();

            foreach (var genre in genres)
            {
                var gameGenre = new GameGenre()
                {
                    GameId = gameId,
                    GenreId = genre.Id,
                };

                genre.GameGenres.Add(gameGenre);
            }

            await genresRepository.SaveChangesAsync();
        }
    }
}
