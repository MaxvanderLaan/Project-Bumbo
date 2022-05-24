using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bumbo.Web.Models.Employee
{
    public class CreateEmployeeModel
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public string Bsn { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z]{4}[0-9]{10}$", ErrorMessage = "Geen geldig Iban: NL99BANK0123456789")]
        public string Iban { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Voer een geldige voornaam in")]
        public string FirstName { get; set; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Voer een geldige tussenvoegesel in")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Voer een geldige achternaam in")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [DataType(DataType.Date, ErrorMessage = "Niet geldige datum format")]
        public DateTime BirthDate { get; set; }

        [MaxLength(6)]
        [RegularExpression("^[0-9]{4}[A-Z]{2}|[0-9]{5}$", ErrorMessage = "Dit veld is geen geldige Zipcode")]
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[0-9a-zA-Z-]{1,10}", ErrorMessage = "Geen geldig huisnummer")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige straatnaam ing")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige stad in")]
        public string City { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige provincie in")]
        public string State { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige land in")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [Phone(ErrorMessage = "Dit is geen geldig Telefoon nummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig Email Adres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Je moet er minimaal één afdeling hebben geselecteerd")]
        public List<int> Departments { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        public Period Period { get; set; }

        public string Url { get; set; }
    }
}
