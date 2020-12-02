using GameDatabase.Data.Common.Models;
using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Genre : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Description { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}