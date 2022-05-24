using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Credentials
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Adress veld is leeg")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord veld is leeg")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?!.* )(?=.*\d)(?=.*[A-Z])[a-zA-Z0-9]+$", ErrorMessage = "Password must meet requirements")]
        [Display(Name = "Wachtwoord")]
        [MinLength(6, ErrorMessage = "Het wachtwoord moet minimaal 6 characters lang zijn!")]
        [MaxLength(128, ErrorMessage = "Het wachtwoord mag maximaal 128 characters lang zijn!")]
        public string Password { get; set; }

        [Display(Name = "ReturnUrl")]
        public string returnUrl { get; set; }
    }
}
