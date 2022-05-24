using Bumbo.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bumbo.Web.Models
{
    public class BranchViewModel : IValidatableObject
    {
        public Branch Branch { get; set; }
        public List<OpeningDay> OpeningDays { get; set; }
        public OpeningDay Monday { get; set; }
        public OpeningDay Tuesday { get; set; }
        public OpeningDay Wednesday { get; set; }
        public OpeningDay Thursday { get; set; }
        public OpeningDay Friday { get; set; }
        public OpeningDay Saturday { get; set; }
        public OpeningDay Sunday { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Branch.PhoneNumber.All(char.IsDigit))
                yield return new ValidationResult($"Het telefoonnummer { Branch.PhoneNumber } is niet geldig.");
            if (Monday.OpenTime >= Monday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Monday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Monday.CloseTime } van maandag.");
            if (Tuesday.OpenTime >= Tuesday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Tuesday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Tuesday.CloseTime } van dinsdag.");
            if (Wednesday.OpenTime >= Wednesday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Wednesday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Wednesday.CloseTime } van woensdag.");
            if (Thursday.OpenTime >= Thursday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Thursday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Thursday.CloseTime } van donderdag.");
            if (Friday.OpenTime >= Friday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Friday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Friday.CloseTime } van vrijdag.");
            if (Saturday.OpenTime >= Saturday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Saturday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Saturday.CloseTime } van zaterdag.");
            if (Sunday.OpenTime >= Sunday.CloseTime)
                yield return new ValidationResult($"De openingstijd van { Sunday.OpenTime } mag niet later of even laat zijn dan de sluitingstijd van { Sunday.CloseTime } van zondag.");
        }

        public void AddOpeningDays()
        {
            OpeningDays = new();
            OpeningDays.Add(Monday);
            OpeningDays.Add(Tuesday);
            OpeningDays.Add(Wednesday);
            OpeningDays.Add(Thursday);
            OpeningDays.Add(Friday);
            OpeningDays.Add(Saturday);
            OpeningDays.Add(Sunday);
        }
    }
}
