using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGenresService
    {
        TViewModel GetGenreById<TViewModel>(int id);

        IEnumerable<TViewModel> GetAllGenres<TViewModel>();

        Task<int> Create(GenreInputModel input);

        int GetCount();

        IEnumerable<SelectListItem> GetAllGenresAsOptions(int[] selectedIds);

        Task RelateGameWithGenres(int id, int[] genreIds);
    }
}
