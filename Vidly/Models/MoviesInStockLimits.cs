using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MoviesInStockLimits : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock <= 0 || movie.NumberInStock >= 21)
            {
                return new ValidationResult("Must a be between 1 and 20");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}