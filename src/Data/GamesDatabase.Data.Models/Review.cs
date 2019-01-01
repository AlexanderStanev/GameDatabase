using GamesDatabase.Data.Core;
using System;

namespace GamesDatabase.Data.Models
{
    public class Review : BaseModel<int>
    {
        public Game Game { get; set; }

        public GamesDatabaseUser Author { get; set; }

        public double Rating { get; set; }

        public string Title  { get; set; }

        public string Content { get; set; }
    }
}