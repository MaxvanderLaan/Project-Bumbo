using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Web.Models
{
    public class FunctionDepartmentViewModel 
    {
        public List<Function> Functions { get; set; }
        public List<Department> Departments { get; set; }
        public Function Function { get; set; }
        public Department Department { get; set; }
    }
}
