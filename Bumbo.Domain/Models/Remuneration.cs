using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Remuneration
    {
        [Key] public int RenumerationId { get; set; }
        public int EmployeeId { get; set; }
        [DisplayName("Datum")]
        public DateTime Date { get; set; }
        [DisplayName("Totaal uren")]
        [Required(ErrorMessage = "Vul alsjeblieft de uren in.")]
        [Range(typeof(TimeSpan), "00:00", "23:59", ErrorMessage = "Totaal uren moeten minimaal 00:00 of maximaal 23:59")]
        public TimeSpan? Hours { get; set; }
        [DisplayName("Toeslag")]
        public double SurtaxRate { get; set; }
        [DisplayName("Status")]
        public bool IsApproved { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}