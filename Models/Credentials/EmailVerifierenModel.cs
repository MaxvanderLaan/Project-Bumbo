using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Credentials
{
    public class EmailVerifierenModel
    {
        [Required(ErrorMessage = "Email Adress veld is leeg")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string email { get; set; }

        public string token { get; set; }
    }
}
