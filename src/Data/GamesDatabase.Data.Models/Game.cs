﻿using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Data.Models
{
    public class Game : BaseModel<int>
    {
        public GamesDatabaseUser Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Byte[] Image { get; set; }

        public double Raiting { get; set; }

        public int ReviewsCount { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        // public IEnumerable<Game> RelatedGames { get; set; } 
    }
}
