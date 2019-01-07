using System.Collections.Generic;
using System.Threading.Tasks;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Models.InputModels;
using GamesDatabase.Services.Models.ViewModels.Game;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGamesService
    {
        TViewModel GetGameById<TViewModel>(int id);

        IEnumerable<GameDetailsViewModel> GetRandomGames(int count);

        IEnumerable<GameDetailsViewModel> GetAllGamesByGenreId(int id);

        IEnumerable<GameDetailsViewModel> GetLatestReleasedGames(int count);

        IEnumerable<GameDetailsViewModel> GetAllGames();

        Task<int> Create(GameInputModel input);

        int GetCount();
    }
}
