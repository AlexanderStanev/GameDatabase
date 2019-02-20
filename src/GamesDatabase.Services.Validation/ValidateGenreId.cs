using System.ComponentModel.DataAnnotations;
using GamesDatabase.Services.DataServices.Interfaces;

namespace GamesDatabase.Services.Validation
{
    public class ValidCategoryIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IGenresService)validationContext
                .GetService(typeof(IGenresService));

            if (service.IsGenreIdValid((int)value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid category id!");
            }
        }
    }
}