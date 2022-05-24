using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Registration
    {
        [Key] public int RegistrationId { get; set; }
        public int EmployeeId { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? CorrectClocking { get; set; }
        
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}