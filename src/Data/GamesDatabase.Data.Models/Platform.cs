using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Platform : BaseModel
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}