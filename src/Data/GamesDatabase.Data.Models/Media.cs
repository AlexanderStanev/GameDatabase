using GameDatabase.Data.Common.Models;
using GamesDatabase.Data.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public abstract class Media : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(36)]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [MaxLength(2048)]
        public string Path { get; set; }
    }
}