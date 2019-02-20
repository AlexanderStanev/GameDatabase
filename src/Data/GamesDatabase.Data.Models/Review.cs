using GamesDatabase.Data.Core;
using System;

namespace GamesDatabase.Data.Models
{
    public class Review : BaseModel<int>
    {
        public int GameId { get; set; }

        public int AuthorId { get; set; }

        //public double Rating { get; set; }

        public string Title  { get; set; }

        public string Content { get; set; }
    }
}