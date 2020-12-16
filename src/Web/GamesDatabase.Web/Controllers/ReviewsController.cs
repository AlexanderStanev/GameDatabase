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

        public ActionResult<IEnumerable<ReviewViewModel>> GetReviews(int page)
        {
            var userId = userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId) || userId == Guid.Empty.ToString())
            {
                return BadRequest("User could not be found.");
            }

            var gameId = 1;
            var currentUserReview = reviewsService.GetByUserAndGame<ReviewViewModel>(userId, gameId);
            if (currentUserReview != null)
            {
                currentUserReview.IsCurrentUserReview = true;
            }

            var reviews = new List<ReviewViewModel>
            {
                currentUserReview
            };

            var otherUsersReviews = reviewsService.GetAllExceptForTheGivenUser<ReviewViewModel>(userId, page, Common.GlobalConstants.DefaultItemsPerPage);
            reviews.AddRange(otherUsersReviews);

            return reviews;
        }
    }
}
