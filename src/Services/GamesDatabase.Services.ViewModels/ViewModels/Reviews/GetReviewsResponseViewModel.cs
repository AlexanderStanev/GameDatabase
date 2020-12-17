using System.Collections.Generic;

namespace GamesDatabase.Web.Models.ViewModels.Reviews
{
    public class GetReviewsResponseViewModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        public ReviewViewModel CurrentUserReview { get; set; }

        public double AverageRating { get; set; }
    }
}