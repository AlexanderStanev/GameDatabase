using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Company : BaseModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [MaxLength(128)]
        public string Country { get; set; }

        // public IEnumerable<Game> BestGames { get; set; }
    }

    public enum Status
    {
        Active,
        Inactive,
    }
}