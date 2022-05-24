using System.Collections.Generic;

namespace Bumbo.Domain.Models
{
    public class ProfileColleague
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeHasDepartments> Departments { get; set; }

        public string PhoneNumber { get; set; }
    }
}