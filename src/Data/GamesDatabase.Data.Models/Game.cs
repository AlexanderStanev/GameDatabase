using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesDatabase.Data.Models
{
    public class Game : BaseModel
    {
        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Description { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Release> Releases { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }

        public virtual ICollection<Platform> Platforms { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [Required]
        [MaxLength(36)]
        public string GameEngineId { get; set; }

        public virtual GameEngine GameEngine { get; set; }

        public DateTime? Announced { get; set; }

        [MaxLength(2048)]
        public string OfficialWebsite { get; set; }
    }
}
