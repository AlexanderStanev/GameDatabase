using System.ComponentModel.DataAnnotations;

namespace GamesDatabase.Data.Models
{
    public class Image : Media
    {
        [Required]
        public ImageType ImageType { get; set; }
    }

    public enum ImageType
    {
        Cover,
        Background,
        Normal
    }
}