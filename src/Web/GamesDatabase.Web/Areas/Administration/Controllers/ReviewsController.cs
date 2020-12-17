using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Web.Models.ViewModels.Genres;
using GamesDatabase.Web.Models.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class ReviewsController : AdministrationBaseController
    {
        private readonly IReviewsService reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        public IActionResult All()
        {
            var genres = reviewsService.GetAll<ReviewViewModel>(1, Common.GlobalConstants.DefaultItemsPerPage);
            return this.View(genres);
        }
    }
}
