using GamesDatabase.Web.Models.InputModels;
using GamesDatabase.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IGamesService
    {
        TViewModel GetGameById<TViewModel>(int id);

        IEnumerable<TViewModel> GetRandom<TViewModel>(int count);

        IEnumerable<TViewModel> GetLatestReleased<TViewModel>(int count);

        IEnumerable<TViewModel> GetAll<TViewModel>(string title, int[] genreIds, int page, int itemsPerPage);

        int GetCount();

        Task<int> Create(GameInputModel input, string rootPath);

        Task<int> Update(GameInputModel input);

        Task Delete(int id);
    }
}
