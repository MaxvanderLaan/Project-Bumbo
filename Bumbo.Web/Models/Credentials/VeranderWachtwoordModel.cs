using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Credentials
{
    public class VeranderWachtwoordModel
    {
        [Required(ErrorMessage = "Email Adress veld is leeg")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nieuwe Wachtwoord veld is leeg")]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuwe Wachtwoord")]
        [MinLength(6, ErrorMessage = "Het wachtwoord moet minimaal 6 characters lang zijn!")]
        [MaxLength(128, ErrorMessage = "Het wachtwoord mag maximaal 128 characters lang zijn!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bevestig Wachtwoord veld is leeg")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig Wachtwoord")]
        [Compare("Password", ErrorMessage = "Het wachtwoord is niet het zelfde!")]
        public string Password2 { get; set; }

        public string token { get; set; }
    }
}
