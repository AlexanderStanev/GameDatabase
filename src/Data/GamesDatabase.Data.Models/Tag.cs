using GameDatabase.Data.Common.Models;
using GamesDatabase.Data.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Tag : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(16)]
        public string Name { get; set; }
    }
}