using System.ComponentModel.DataAnnotations;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;

namespace GamesDatabase.Services.Models.InputModels
{
    public class GenreInputModel : IMapTo<Genre>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
