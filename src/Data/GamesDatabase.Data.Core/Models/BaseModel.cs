using System;
using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Core
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        public BaseModel()
        {
            if (typeof(TKey) == typeof(string))
            {
                this.Id = (TKey)(object)Guid.NewGuid().ToString();
            }
        }

        [Required]
        [MaxLength(36)]
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
