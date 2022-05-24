using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Agenda
{
    public class PublishViewModel : IValidatableObject
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate) 
                yield return new ValidationResult("De startdatum kan niet na de einddatum vallen.");

            if (StartDate < DateTime.Now)
                yield return new ValidationResult("De startdatum kan niet in het verleden vallen.");

            if (EndDate < DateTime.Now) 
                yield return new ValidationResult("De einddatum kan niet in het verleden vallen.");
            
        }
    }
}