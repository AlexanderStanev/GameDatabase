using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGenresService
    {
        TViewModel GetGenreById<TViewModel>(string id);

        IEnumerable<GenreViewModel> GetAllGenres();

        Task<string> Create(GenreInputModel input);

        bool IsGenreIdValid(string categoryId);

        int GetCount();

    }
}
