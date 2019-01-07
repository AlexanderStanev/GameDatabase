using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GamesDatabase.Data.Models;

namespace GamesDatabase.Services.Models.InputModels
{
    public class GameInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateReleased { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Developer { get; set; }
    }
}