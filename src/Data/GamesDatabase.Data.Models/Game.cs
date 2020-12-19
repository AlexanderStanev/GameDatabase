using GameDatabase.Data.Core.Models;
using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesDatabase.Data.Models
{
    public class Game : BaseDeletableModel<int>
    {
        public Game()
        {
            this.GameGenre = new HashSet<GameGenre>();
            this.Images = new HashSet<Image>();
            this.Reviews = new HashSet<Review>();
            this.Tags = new HashSet<Tag>();
        }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Description { get; set; }

        public ICollection<GameGenre> GameGenre { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public DateTime? Released { get; set; }

        [Required]
        [MaxLength(2048)]
        public string OfficialWebsite { get; set; }

        // TODO: Might not be used

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }

        public virtual ICollection<Platform> Platforms { get; set; }

        public int? GameEngineId { get; set; }

        public virtual GameEngine GameEngine { get; set; }
    }
}
