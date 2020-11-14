using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamesDatabase.Data.Models
{
    public class GameGenre : BaseModel
    {
        [Required]
        [MaxLength(36)]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [MaxLength(36)]
        public string GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
