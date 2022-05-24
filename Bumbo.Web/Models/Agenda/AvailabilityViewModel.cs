using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Schedules;
using Microsoft.Extensions.DependencyInjection;

namespace Bumbo.Web.Models.Agenda
{
    public class AvailabilityViewModel : IValidatableObject
    {
        public Availability Availability { get; set; }
        public List<Availability> Availabilities { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ISchedule service = validationContext.GetService<ISchedule>();

            if (Availability.Start > Availability.End)
                yield return new ValidationResult("De startdatum kan niet na de einddatum vallen.");

            if (Availability.Start < DateTime.Now)
                yield return new ValidationResult("De startdatum kan niet in het verleden vallen.");

            if (Availability.End < DateTime.Now)
                yield return new ValidationResult("De einddatum kan niet in het verleden vallen.");

            if (Availability.Start == Availability.End)
                yield return new ValidationResult("Deze beschikbaarheid bevat geen looptijd.");

            if (service != null)
            {
                if (service.GetAvailabilityOverlapExclude(Availability.EmployeeId, Availability.Id, Availability.Start, Availability.End))
                    yield return new ValidationResult("U bent al onbeschikbaar gedurende deze periode.");

                if (Availability.Type != Availability.AvailabilityType.Ziek)
                    if (service.GetScheduleOverlap(Availability.EmployeeId, Availability.Start, Availability.End))
                        yield return new ValidationResult("U bent ingeroosterd gedurende deze periode.");
            }
        }
    }
}