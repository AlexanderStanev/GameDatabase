using System;
using System.ComponentModel.DataAnnotations;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;

namespace GamesDatabase.Services.Models.InputModels
{
    public class GameInputModel : IMapTo<Game>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(3000)]
        public string Description { get; set; }

        [Required]
        public string GenreId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateReleased { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Developer { get; set; }
    }
}