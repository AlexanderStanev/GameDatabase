using GamesDatabase.Web.Models.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IReviewsService
    {
        TViewModel GetByUserAndGame<TViewModel>(string userId, int gameId);

        IEnumerable<TViewModel> GetAllExceptForTheGivenUser<TViewModel>(string userId, int page, int itemsPerPage);

        double GetAverageRatingOfGame<TViewModel>(int gameId);

        int? GetIdByUserAndGame(string userId, int gameId);

        int GetCount();

        Task Create(ReviewInputModel input);

        Task Update(ReviewInputModel input);

        Task Delete(int id);
    }
}
