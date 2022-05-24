using System.ComponentModel;

namespace Bumbo.Web.Models.Remuneration
{
    public class RemunerationDownloadEmployeeModel
    {
        [DisplayName("Werknemer Id")]
        public int EmployeeId { get; set; }
        [DisplayName("Vestigings Id")]
        public int BranchId { get; set; }
        [DisplayName("Uitbetaling Periode")]
        public string Period { get; set; }
        [DisplayName("Voornaam")]
        public string FirstName { get; set; }
        [DisplayName("Tussenvoegsel")]
        public string MiddleName { get; set; }
        [DisplayName("Achternaam")]
        public string LastName { get; set; }
        [DisplayName("Rekeningnummer")]
        public string Iban { get; set; }
        [DisplayName("Geboortedatum")]
        public string BirthDate { get; set; }
        [DisplayName("Postcode")]
        public string ZipCode { get; set; }
        [DisplayName("Huisnummer")]
        public string HouseNumber { get; set; }
        [DisplayName("Straatnaam")]
        public string StreetName { get; set; }
        [DisplayName("Stad")]
        public string City { get; set; }
        [DisplayName("Provincie")]
        public string State { get; set; }
        [DisplayName("Land")]
        public string Country { get; set; }
    }
}