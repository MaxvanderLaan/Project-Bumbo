using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Credentials
{
    public class WachtwoordVergetenModel
    {
        [Required(ErrorMessage = "Email Adress veld is leeg")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public string Url { get; set; }
    }
}
