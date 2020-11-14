using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System;

namespace GamesDatabase.Web.Models.ViewModels
{
    public class SimpleGameViewModel : IMapFrom<Game>
    {
        public string Title { get; set; }

        public double Raiting { get; set; }

        public int ReviewsCount { get; set; }

        public DateTime DateReleased { get; set; }

        public string Developer { get; set; }
    }
}