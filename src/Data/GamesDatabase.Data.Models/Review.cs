using GameDatabase.Data.Core.Models;
using GamesDatabase.Data.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Review : BaseDeletableModel<int>
    {
        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Content { get; set; }
    }
}