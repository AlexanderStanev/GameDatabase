using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGamesService
    {
        TViewModel GetGameById<TViewModel>(string id);

        IEnumerable<TViewModel> GetRandomGames<TViewModel>(int count);

        IEnumerable<TViewModel> GetAllGamesByGenreId<TViewModel>(string id);

        IEnumerable<TViewModel> GetLatestReleasedGames<TViewModel>(int count);

        IEnumerable<TViewModel> GetAllGames<TViewModel>();

        Task<string> Create(GameInputModel input);

        int GetCount();
    }
}
