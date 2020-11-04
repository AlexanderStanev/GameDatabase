using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGamesService
    {
        TViewModel GetGameById<TViewModel>(string id);

        IEnumerable<DetailedGameViewModel> GetRandomGames(int count);

        IEnumerable<DetailedGameViewModel> GetAllGamesByGenreId(string id);

        IEnumerable<DetailedGameViewModel> GetLatestReleasedGames(int count);

        IEnumerable<DetailedGameViewModel> GetAllGames();

        Task<string> Create(GameInputModel input);

        int GetCount();
    }
}
