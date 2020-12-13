using GameDatabase.Data.Core.Models;
using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamesDatabase.Data.Models
{
    public class GameGenre : BaseDeletableModel<int>
    {
        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
