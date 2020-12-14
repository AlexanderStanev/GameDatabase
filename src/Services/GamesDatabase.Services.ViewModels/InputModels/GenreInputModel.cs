using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Web.Models.InputModels
{
    public class GenreInputModel : IMapTo<Genre>, IMapFrom<Genre>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
