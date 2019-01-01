using GamesDatabase.Data.Core;
using System;

namespace GamesDatabase.Data.Models
{
    public class Genre : BaseModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}