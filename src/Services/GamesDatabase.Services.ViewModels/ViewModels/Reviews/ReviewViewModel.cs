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
        public string AuthorUserName { get; set; }

        public int Rating { get; set; }

        public double AverageRating { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
