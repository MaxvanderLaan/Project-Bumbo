using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Employee
{
    public class EditEmployeeModel
    {
        public Domain.Models.Employee Employee { get; set; }

        [Required(ErrorMessage = "Je moet minimaal één afdeling hebben geselecteerd")]
        public List<int> Departments { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [Phone(ErrorMessage = "Dit is geen geldig Telefoon nummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig Email Adres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Je moet minimaal één roll hebben geselecteerd")]
        public string Roll { get; set;}

        public string Url { get; set; }
    }
}
