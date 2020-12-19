using GameDatabase.Data.Core.Models;
using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamesDatabase.Data.Models
{
    public class ContactForm : BaseDeletableModel<int>
    {
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Description { get; set; }
    }
}
