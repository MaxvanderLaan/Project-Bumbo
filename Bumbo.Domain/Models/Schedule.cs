using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class Schedule
    {
        [Key] public int ScheduleId { get; set; }
        
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finalised { get; set; }
    }
}