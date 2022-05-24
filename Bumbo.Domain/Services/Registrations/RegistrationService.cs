using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Registrations
{
    public class RegistrationService : IRegistration
    {
        private readonly BumboContext ctx;

        public RegistrationService(BumboContext context)
        {
            ctx = context;
        }

        public Registration nfcRegistration(int tagId, DateTime dateTime)
        {
            Employee employee = ctx.Employees.Where(e => e.TagId == tagId).FirstOrDefault();
            if (employee != null)
            {
                Registration Registration = ctx.Registrations.Where(r => r.EmployeeId == employee.EmployeeId && r.EndDate == null).OrderBy(r => r.StartDate).FirstOrDefault();
                if (Registration == null)
                {
                    Registration = new Registration();
                    Registration.EmployeeId = employee.EmployeeId;
                    Registration.Employee = employee;
                    Registration.StartDate = dateTime;
                    ctx.Attach(Registration);
                    ctx.Add(Registration);
                }
                else
                {
                    Registration.EndDate = dateTime;
                    Registration.CorrectClocking = true;
                    ctx.Attach(Registration);
                    ctx.Update(Registration);
                }
                ctx.SaveChanges();
                return Registration;
            }
            else
            {
                return null;
            }
        }

        public void checkClocking()
        {
            List<Registration> registration = ctx.Registrations.Where(r => r.EndDate == null).OrderBy(r => r.StartDate).ToList();
            if(registration.Count != 0)
            {
                TimeSpan timespan = new TimeSpan(2, 0, 0);
                for (int i = 0; i < registration.Count; i++)
                {
                    registration[i].EndDate = registration[i].StartDate.Date.AddDays(1) + timespan;
                    registration[i].CorrectClocking = false;
                    ctx.Registrations.Attach(registration[i]);
                    ctx.Registrations.Update(registration[i]);
                }
                ctx.SaveChanges();
            }
        }

        public int SetTagIdWithEmployeeId(int employeeId)
        {
            Employee employee = ctx.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
            if (employee == null)
            {
                return 0;
            }
            else
            {
                if (employee.TagId == null)
                {
                    int? higestID = ctx.Employees.Select(emp => emp.TagId).ToList().Max();
                    if (higestID == 0 || higestID == null)
                    {
                        employee.TagId = 1;
                        ctx.Employees.Attach(employee);
                        ctx.Employees.Update(employee);
                        ctx.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        higestID++;
                        employee.TagId = higestID;
                        ctx.Employees.Attach(employee);
                        ctx.Employees.Update(employee);
                        ctx.SaveChanges();
                        return (int)higestID;
                    }
                }
                else
                {
                    return (int)employee.TagId;
                }
            }
        }
    }
}
