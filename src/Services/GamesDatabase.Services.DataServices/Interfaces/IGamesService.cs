using System.Collections.Generic;
using System.Threading.Tasks;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Models.InputModels;
using GamesDatabase.Services.Models.ViewModels;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGamesService
    {
        TViewModel GetGameById<TViewModel>(int id);

        IEnumerable<DetailedGameViewModel> GetRandomGames(int count);

        IEnumerable<DetailedGameViewModel> GetAllGamesByGenreId(int id);

        IEnumerable<DetailedGameViewModel> GetLatestReleasedGames(int count);

        IEnumerable<DetailedGameViewModel> GetAllGames();

        Task<int> Create(GameInputModel input);

        int GetCount();
    }
}
