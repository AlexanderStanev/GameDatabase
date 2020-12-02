using GameDatabase.Data.Common.Models;
using GamesDatabase.Data.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Release : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(36)]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [MaxLength(36)]
        public string PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(64)]
        public string Version { get; set; }
    }
}