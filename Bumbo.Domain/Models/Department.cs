using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bumbo.Domain.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Afdeling")]
        public DepartmentName Name { get; set; }
        [DisplayName("Afdelingcode")]
        public DepartmentCode Code { get; set; }
        public virtual List<EmployeeHasDepartments> Employees { get; set; }


        public enum DepartmentName
        {
            Kassa = 0,
            Vers = 1,
            Vakkenvullen = 2
        }

        public enum DepartmentCode
        {
            VER = 0,
            VAK = 1,
            KAS = 2
        }
    }
}