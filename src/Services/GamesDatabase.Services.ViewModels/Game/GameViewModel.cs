using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System;
using System.Collections.Generic;

namespace GamesDatabase.Services.ViewModels
{
    public class GameViewModel : IMapFrom<Game>
    {
        public GamesDatabaseUser Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Byte[] Image { get; set; }

        public double Raiting { get; set; }

        public int ReviewsCount { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}