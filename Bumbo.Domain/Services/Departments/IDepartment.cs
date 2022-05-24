using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Departments
{
    public interface IDepartment
    {
        List<Department> GetAll();
    }
}
