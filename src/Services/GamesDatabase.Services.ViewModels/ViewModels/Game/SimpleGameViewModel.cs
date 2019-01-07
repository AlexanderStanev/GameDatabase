using System.Collections.Generic;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;

namespace GamesDatabase.Services.Models.ViewModels.Game
{
    public class SimpleGameViewModel : IMapFrom<Data.Models.Game>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Raiting { get; set; }

        public int ReviewsCount { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}