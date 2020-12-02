using GameDatabase.Data.Common.Models;
using GamesDatabase.Data.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Review : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(36)]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        //[Required]
        //[MaxLength(36)]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public byte Rating { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? EditedOn { get; set; }
    }
}