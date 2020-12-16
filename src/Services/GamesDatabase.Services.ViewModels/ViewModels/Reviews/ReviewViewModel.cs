using AutoMapper;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Web.Models.ViewModels.Reviews
{
    public class ReviewViewModel : IMapFrom<Review>
    {
        public bool IsCurrentUserReview;

        public string AuthorUserName { get; set; }

        public int Rating { get; set; }

        public string Content { get; set; }
    }
}
