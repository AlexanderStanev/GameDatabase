namespace GamesDatabase.Web.Controllers
{
    using GamesDatabase.Data.Models;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : BaseController
    {
        private readonly IReviewsService reviewsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewsController(IReviewsService reviewsService,
            UserManager<ApplicationUser> userManager)
        {
            this.reviewsService = reviewsService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SubmitReview(ReviewInputModel inputModel)
        {
            var userId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId) || userId == Guid.Empty.ToString())
            {
                return BadRequest("User could not be found.");
            }

            inputModel.AuthorId = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewId = reviewsService.GetIdByUserAndGame(userId, inputModel.GameId);
            if (reviewId.HasValue)
            {
                inputModel.Id = reviewId.Value;
                await reviewsService.Update(inputModel);
            }
            else
            {
                await reviewsService.Create(inputModel);
            }

            return Ok();
        }

        // TODO: Remove Review functionality

        //[Authorize]
        //[HttpDelete]
        //public async Task<ActionResult> RemoveReview()
        //{
        //    var userId = userManager.GetUserId(User);
        //    if (string.IsNullOrEmpty(userId) || userId == Guid.Empty.ToString())
        //    {
        //        return BadRequest("User could not be found.");
        //    }
        //}

        public ActionResult<GetReviewsResponseViewModel> GetReviews(int page, int gameId)
        {
            if (gameId < 1 || page < 1)
            {
                return BadRequest("Invalid game or page parameter.");
            }

            var reviews = reviewsService.GetAllByGameId<ReviewViewModel>(gameId, page, Common.GlobalConstants.DefaultItemsPerPage);
            if (!reviews.Any())
            {
                return Ok("No reviews found.");
            }

            var userId = userManager.GetUserId(User);
            var currentUserReview = reviewsService.GetByUserAndGame<ReviewViewModel>(userId, gameId);

            var averageRating = reviewsService.GetAverageRatingOfGame(gameId);
            var reponse = new GetReviewsResponseViewModel()
            {
                Reviews = reviews,
                AverageRating = averageRating,
                CurrentUserReview = currentUserReview,
            };

            return reponse;
        }
    }
}
