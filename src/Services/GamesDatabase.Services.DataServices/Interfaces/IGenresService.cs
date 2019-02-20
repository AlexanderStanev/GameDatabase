using System.Collections.Generic;
using System.Threading.Tasks;
using GamesDatabase.Services.Models.InputModels;
using GamesDatabase.Services.Models.ViewModels;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGenresService
    {
        TViewModel GetGenreById<TViewModel>(int id);

        IEnumerable<GenreViewModel> GetAllGenres();

        Task<int> Create(GenreInputModel input);

        bool IsGenreIdValid(int categoryId);

        int GetCount();

    }
}
