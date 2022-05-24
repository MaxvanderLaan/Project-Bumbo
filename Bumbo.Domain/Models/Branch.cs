using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bumbo.Domain.Models
{
    public class Branch
    {
        [Key] 
        public int BranchId { get; set; }
        [DisplayName("Branchnaam")]
        [Required(ErrorMessage = "Vul alsjeblieft de naam in.")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige naam in")]
        public string Name { get; set; }
        [DisplayName("Telefoonnummer")]
        [Required(ErrorMessage = "Vul alsjeblieft het telefoonnummer in.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Het telefoonnummer is niet geldig.")]
        public string PhoneNumber { get; set; }
        [DisplayName("E-Mailadres")]
        [Required(ErrorMessage = "Vul alsjeblieft het e-mailadres in")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Het e-mailadres is niet geldig.")]
        public string Email { get; set; }
        [DisplayName("Postcode")]
        [Required(ErrorMessage = "Vul alsjeblieft de postcode in.")]
        public string ZipCode { get; set; }
        [DisplayName("Huisnummer")]
        [Required(ErrorMessage = "Vul alsjeblieft het huisnummer in.")]
        public string HouseNumber { get; set; }
        [DisplayName("Straatnaam")]
        [Required(ErrorMessage = "Vul alsjeblieft de naam van de straat in.")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige straatnaam in")]
        public string StreetName { get; set; }
        [DisplayName("Stad")]
        [Required(ErrorMessage = "Vul alsjeblieft de naam van de stad in.")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige stad in")]
        public string City { get; set; }
        [DisplayName("Provincie")]
        [Required(ErrorMessage = "Vul alsjeblieft de provincie in.")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige provincie in")]
        public string State { get; set; }
        [DisplayName("Land")]
        [Required(ErrorMessage = "Vul alsjeblieft het land in")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige land in")]
        public string Country { get; set; }
        [DisplayName("Lengte aan schappen in meters")]
        [Required(ErrorMessage = "Vul alsjeblieft het aantal meters aan schappen in.")]
        [RegularExpression(@"^[0-9]{1,4}$", ErrorMessage = "Vul alsjeblieft alleen nummers in. Het maximum aantal meters is 9999.")]
        public int ShelvesLength { get; set; }
        public List<OpeningDay> OpeningDays { get; set; }
        public List<Forecast> Forecasts { get; set; }
        public List<Standard> Standards { get; set; }
    }
}