using GameDatabase.Data.Common.Models;
using GamesDatabase.Data.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class GameEngine : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public string Language { get; set; }
    }
}