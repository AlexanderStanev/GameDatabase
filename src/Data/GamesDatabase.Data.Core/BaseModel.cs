using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Core
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(36)]
        public string Id { get; set; }
    }
}
