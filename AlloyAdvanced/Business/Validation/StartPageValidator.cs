using AlloyAdvanced.Models.Pages;
using EPiServer.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyAdvanced.Business.Validation
{
    public class StartPageValidator : IValidate<StartPage>
    {
        public IEnumerable<ValidationError> Validate(StartPage instance)
        {
            if(instance.StartDate >= instance.EndDate)
            {
                yield return new ValidationError
                {
                    ErrorMessage = "Startdate must be before enddate.",
                    PropertyName = "StartDate",
                    RelatedProperties = new string[] { "EndDate" },
                    Severity = ValidationErrorSeverity.Error
                };
            }

            if (instance.Name.ToLower().Contains("frak"))
            {
                yield return new ValidationError
                {
                    ErrorMessage = "frak is a bad word. You can use it in the name of a page but we dont recommend it.",
                    PropertyName = "Name",
                    Severity = ValidationErrorSeverity.Warning
                }; 
            }
        }
    }
}