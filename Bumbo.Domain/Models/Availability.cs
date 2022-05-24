using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Availability
    {
        [Key] public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public AvailabilityType Type { get; set; }
        public Status ApprovalStatus { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        
        public enum AvailabilityType
        {
            Onbeschikbaar = 0,
            School = 1,
            Vakantie = 2,
            Ziek = 3,
        }

        public enum Status
        {
            Afwachtend = 0,
            Afgekeurd = 1,
            Goedgekeurd = 2,
        }
    }
}