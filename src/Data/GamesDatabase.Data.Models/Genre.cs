using GamesDatabase.Data.Core;
using System;

namespace GamesDatabase.Data.Models
{
    public class Genre : BaseModel<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}