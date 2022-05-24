using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Departments
{
    public class DepartmentService : IDepartment
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public DepartmentService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public List<Department> GetAll()
        {
            try
            {
                return ctx.Departments.ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}
