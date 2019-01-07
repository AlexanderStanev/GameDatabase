using System.Collections.Generic;
using System.Threading.Tasks;
using GamesDatabase.Services.Models.InputModels;
using GamesDatabase.Services.Models.ViewModels.Game;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGenresService
    {
        TViewModel GetGenreById<TViewModel>(int id);

        IEnumerable<GameDetailsViewModel> GetAllGenres();

        Task<int> Create(GenreInputModel input);

        int GetCount();
    }
}
