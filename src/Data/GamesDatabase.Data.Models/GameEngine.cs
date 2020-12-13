using GameDatabase.Data.Core.Models;
using GamesDatabase.Data.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class GameEngine : BaseDeletableModel<int>
    {
        public GameEngine()
        {
            this.Games = new HashSet<Game>();
        }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public string Language { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}