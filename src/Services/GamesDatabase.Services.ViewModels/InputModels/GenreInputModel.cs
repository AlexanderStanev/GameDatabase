using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Services.Models.InputModels
{
    public class GenreInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
