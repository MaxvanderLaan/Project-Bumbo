using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bumbo.Domain.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Bumbo.Domain.Services.Dashboard
{
    public class DashboardService : IDashboard
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public DashboardService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public void matchUserWithEmployee()
        {
            List<Employee> employees = ctx.Employees.Where(e => e.userId == null).ToList();
            if (employees.Count != 0)
            {
                foreach (Employee employee in employees)
                {
                    string UserName = "";
                    if (employee.MiddleName == null)
                    {
                        UserName = UppercaseFirst(employee.FirstName) + UppercaseFirst(employee.LastName);
                    }
                    else
                    {
                        UserName = UppercaseFirst(employee.FirstName) + UppercaseFirst(employee.MiddleName) + UppercaseFirst(employee.LastName);
                    }
                    Task<IdentityUser> user = _userManager.FindByNameAsync(UserName);
                    employee.userId = user.Result.Id;
                    ctx.Employees.Update(employee);
                }
                ctx.SaveChanges();
            }
        }

        private static string UppercaseFirst(string name)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public List<Registration> getManagerRegistrations(ClaimsPrincipal user)
        {
            Task<IdentityUser> User = _userManager.FindByNameAsync(user.Identity.Name);
            Employee currentEmployee = ctx.Employees.Where(emp => emp.userId == User.Result.Id).FirstOrDefault();
            List<Employee> employees = ctx.Employees.Where(emp => emp.BranchId == currentEmployee.BranchId).ToList();
            return ctx.Registrations.Include(reg => reg.Employee).Where(reg => reg.StartDate.Date == DateTime.Today && employees.Contains(reg.Employee)).OrderByDescending(reg => reg.StartDate).ToList();
        }

        public List<Availability> getManagerAvailability(ClaimsPrincipal user)
        {
            Task<IdentityUser> User = _userManager.FindByNameAsync(user.Identity.Name);
            Employee currentEmployee = ctx.Employees.Where(emp => emp.userId == User.Result.Id).FirstOrDefault();
            List<Employee> employees = ctx.Employees.Where(emp => emp.BranchId == currentEmployee.BranchId).ToList();
            return ctx.Availability.Include(reg => reg.Employee).Where(reg => reg.Start.Date <= DateTime.Today && reg.End.Date >= DateTime.Today && employees.Contains(reg.Employee) && reg.ApprovalStatus == Availability.Status.Goedgekeurd).OrderByDescending(reg => reg.Start).ToList();
        }

        public List<Registration> getMedewerkerRegistrations(ClaimsPrincipal user)
        {
            Task<IdentityUser> User = _userManager.FindByNameAsync(user.Identity.Name);
            Employee employee = ctx.Employees.Where(emp => emp.userId == User.Result.Id).FirstOrDefault();
            return ctx.Registrations.Where(reg => reg.EmployeeId == employee.EmployeeId).OrderByDescending(reg => reg.StartDate).ToList();
        }

        public List<Availability> getMedewerkerAvailability(ClaimsPrincipal user)
        {
            Task<IdentityUser> User = _userManager.FindByNameAsync(user.Identity.Name);
            Employee employee = ctx.Employees.Where(emp => emp.userId == User.Result.Id).FirstOrDefault();
            return ctx.Availability.Where(ava => ava.EmployeeId == employee.EmployeeId && ava.End > DateTime.Now).ToList();
        }
    }
}
