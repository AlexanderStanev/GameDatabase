using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Web.Models.InputModels
{
    public class ReviewInputModel : IMapTo<Review>, IMapFrom<Review>
    {
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        public string AuthorId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "You must select give a score from 1 to 5 by clicking the stars.")]
        public int Rating { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Content { get; set; }
    }
}