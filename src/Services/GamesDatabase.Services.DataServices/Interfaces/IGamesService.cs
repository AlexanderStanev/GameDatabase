using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGamesService
    {
        TViewModel GetGameById<TViewModel>(int id);

        IEnumerable<TViewModel> GetRandomGames<TViewModel>(int count);

        IEnumerable<TViewModel> GetAllGamesByGenreId<TViewModel>(int id);

        IEnumerable<TViewModel> GetLatestReleasedGames<TViewModel>(int count);

        IEnumerable<TViewModel> GetAllGames<TViewModel>(int page, int itemsPerPage);

        Task<int> Create(GameInputModel input, string rootPath);

        Task<int> Update(GameInputModel input);

        Task Delete(int id);

        int GetCount();
    }
}
