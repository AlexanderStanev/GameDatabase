using GamesDatabase.Data.Core;

namespace GamesDatabase.Data.Models
{
    public class Genre : BaseModel<int>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}