using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;

namespace GamesDatabase.Web.Models.ViewModels
{
    public class GenreViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}