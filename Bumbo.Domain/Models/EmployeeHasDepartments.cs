using System.ComponentModel.DataAnnotations.Schema;

namespace Bumbo.Domain.Models
{
    public class EmployeeHasDepartments
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}