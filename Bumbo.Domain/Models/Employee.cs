using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Employee
    {
        [Key] public int EmployeeId { get; set; }
        public string userId { get; set; }
        
        [ForeignKey("Registration")] public int? TagId { get; set; }

        [ForeignKey("Branch")] public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[0-9]{8,9}$", ErrorMessage = "Geen geldig BSN: 123456789")]
        public int Bsn { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z]{4}[0-9]{10}$", ErrorMessage = "Geen geldig Iban: NL99BANK0123456789")]
        public string Iban { get; set; }

        [DisplayName("Uitbetalingsperiode")]
        public Period Period { get; set; }

        [DisplayName("Voornaam")]
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige voornaam in")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsel")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige tussenvoegesel in")]
        public string MiddleName { get; set; }

        [DisplayName("Achternaam")]
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige achternaam in")]
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
        [RegularExpression("^[a-zA-Z-'áàâäåôöòûßïîìçêëèé ]+$", ErrorMessage = "Voer een geldige straatnaam in")]
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
        public virtual List<EmployeeHasDepartments> Departments { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
        public virtual List<Remuneration> Remunerations { get; set; }
        public virtual List<Contract> Contracts { get; set; }
    }

    public enum Period
    {
        Wekelijks = 1,
        ElkeTweeWeken = 2,
        ElkeDrieWeken = 3,
        ElkeVierWeken = 4,
        Maandelijks = 5
    }
}