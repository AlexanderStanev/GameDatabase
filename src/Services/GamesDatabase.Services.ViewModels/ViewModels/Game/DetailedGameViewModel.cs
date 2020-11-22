using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System;
using System.Collections.Generic;

namespace GamesDatabase.Web.Models.ViewModels
{
    public class DetailedGameViewModel : IMapFrom<Game>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        //public double Raiting { get; set; }

        //public int ReviewsCount { get; set; }

        //public IEnumerable<Review> Reviews { get; set; }

        //public DateTime DateReleased { get; set; }
    }
}