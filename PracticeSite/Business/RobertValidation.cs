using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeSite.Business
{
    public class RobertValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ErrorMessage = $"den mailen får du inte använda!!";
            var email = value as string;

            return email != "robertdanielsson@live.com";
        }

        /// <summary>
        /// Validation result
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);

            if (!string.IsNullOrWhiteSpace(result?.ErrorMessage))
            {
                result.ErrorMessage = $"{validationContext.DisplayName} {ErrorMessage}";
            }

            return result;
        }
    }
}