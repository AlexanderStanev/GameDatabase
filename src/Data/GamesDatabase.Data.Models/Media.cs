using GameDatabase.Data.Core.Models;
using GamesDatabase.Data.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public abstract class Media : BaseDeletableModel<string>
    {
        public Media()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Path { get; set; }

        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}