using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bumbo.Domain.Services.Schedules
{
    public class ScheduleService : ISchedule
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public ScheduleService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public void AddSchedule(Schedule schedule)
        {
            ctx.Schedules.Add(schedule);
            ctx.SaveChanges();
        }

        public List<Schedule> GetAllSchedules()
        {
            return ctx.Schedules
                .Include(e => e.Employee)
                .Include(d => d.Department)
                .ToList();
        }

        public Schedule GetSchedule(int id)
        {
            return ctx.Schedules.Include(s => s.Department)
                .FirstOrDefault(s => s.ScheduleId == id);
        }

        public bool GetScheduleOverlap(int employeeId, DateTime startDate, DateTime endDate)
        {
            return ctx.Schedules.Any(s => s.EmployeeId == employeeId && (s.StartDate < endDate && startDate < s.EndDate));
        }
        
        public bool GetScheduleOverlapExclude(int employeeId, int scheduleId, DateTime startDate, DateTime endDate)
        {
            return ctx.Schedules.Any(s => s.ScheduleId != scheduleId && s.EmployeeId == employeeId && (s.StartDate < endDate && startDate < s.EndDate));
        }

        public List<Schedule> GetEmployeePeriodSchedule(int employeeId, DateTime startDate, DateTime endDate)
        {
            return ctx.Schedules.Where(s => s.EmployeeId == employeeId && (s.StartDate.Date >= startDate && s.StartDate <= endDate)).ToList();
        }

        public List<Schedule> GetEmployeeSchedule(int id)
        {
            return ctx.Schedules
                .Include(e => e.Employee)
                .Include(d => d.Department)
                .Where(s => s.EmployeeId == id)
                .ToList();
        }

        public bool GetAvailabilityOverlapExclude(int employeeId, int availabilityId, DateTime startDate, DateTime endDate)
        {
            return ctx.Availability.Any(a => a.Id != availabilityId && a.EmployeeId == employeeId && (startDate < a.End && a.Start < endDate));
        }

        public bool GetAvailabilityOverlap(int employeeId, DateTime startDate, DateTime endDate)
        {
            return ctx.Availability.Any(a =>
                a.EmployeeId == employeeId 
                &&
                a.ApprovalStatus == Availability.Status.Goedgekeurd
                && 
                (startDate < a.End && a.Start < endDate));
        }
        
        public List<Availability> GetEmployeeFutureAvailability(int id)
        {
            return ctx.Availability.Where(a => a.EmployeeId == id && a.End > DateTime.Now).ToList();
        }

        public Availability GetAvailability(int id)
        {
            return ctx.Availability.FirstOrDefault(a => a.Id == id);
        }

        public Availability AddAvailability(Availability availability)
        {
            if (availability.Type == Availability.AvailabilityType.School || availability.Type == Availability.AvailabilityType.Ziek)
            {
                availability.ApprovalStatus = Availability.Status.Goedgekeurd;
            }
            else
            {
                availability.ApprovalStatus = Availability.Status.Afwachtend;
            }
            ctx.Availability.Add(availability);
            ctx.SaveChanges();
            return availability;
        }

        public Availability UpdateAvailability(Availability availability)
        {
            if (availability.Type == Availability.AvailabilityType.School || availability.Type == Availability.AvailabilityType.Ziek)
            {
                availability.ApprovalStatus = Availability.Status.Goedgekeurd;
            }
            else
            {
                availability.ApprovalStatus = Availability.Status.Afwachtend;
            }
            ctx.Availability.Update(availability);
            ctx.SaveChanges();
            return availability;
        }

        public Availability DeleteAvailability(int id)
        {
            Availability availability = ctx.Availability.FirstOrDefault(a => a.Id == id);
            if (availability != null)
            {
                ctx.Availability.Remove(availability);
                ctx.SaveChanges();
                return availability;
            }
            return null;
        }

        public void UpdateSchedule(Schedule schedule)
        {
            ctx.Schedules.Update(schedule);
            ctx.SaveChanges();
        }

        public void DeleteSchedule(int id)
        {
            Schedule schedule = ctx.Schedules.FirstOrDefault(s => s.ScheduleId == id);
            if (schedule != null)
            {
                ctx.Schedules.Remove(schedule);
                ctx.SaveChanges();
            }
        }

        public List<Department> GetDepartments()
        {
            return ctx.Departments.ToList();
        }

        public List<Employee> GetAvailableEmployees()
        {
            return ctx.Employees.Include(e => e.Departments).ToList();
        }

        public List<Employee> GetSchedulableEmployees(int branchId)
        {
            return ctx.Employees
                .Include(e => e.Departments)
                .Include(e => e.Contracts)
                .Where(e => e.BranchId == branchId && e.Contracts
                    .Any(c => (c.EndDate > DateTime.Today || c.EndDate == null) && c.StartDate < DateTime.Now))
                .ToList();
        }

        public List<Availability> GetUnapprovedAvailabilities()
        {
            return ctx.Availability
                .Where(e => e.ApprovalStatus == Availability.Status.Afwachtend && e.Start.Date >= DateTime.Today)
                .Include(a => a.Employee)
                .ToList();
        }

        public List<Availability> GetApprovedAvailabilities()
        {
            return ctx.Availability.Where(e => e.ApprovalStatus == Availability.Status.Goedgekeurd).ToList();
        }

        public Employee GetEmployee(int employeeId)
        {
            return ctx.Employees.Include(e => e.Departments).FirstOrDefault(e => e.EmployeeId == employeeId);
        }
        
        public void Approve(int id)
        {
            Availability availability = ctx.Availability.FirstOrDefault(a => a.Id == id);
            if (availability != null)
            {
                availability.ApprovalStatus = Availability.Status.Goedgekeurd;
                ctx.Update(availability);
                ctx.SaveChanges();
            }
        }

        public void Disapprove(int id)
        {
            Availability availability = ctx.Availability.FirstOrDefault(a => a.Id == id);
            if (availability != null)
            {
                availability.ApprovalStatus = Availability.Status.Afgekeurd;
                ctx.Update(availability);
                ctx.SaveChanges();
            }
        }

        public void PublishSchedule(DateTime startDate, DateTime endDate)
        {
            foreach (Schedule schedule in ctx.Schedules.Where(s => s.StartDate >= startDate && s.EndDate <= endDate).ToList())
            {
                if (!schedule.Finalised)
                {
                    schedule.Finalised = true;
                    ctx.Update(schedule);
                }
                ctx.SaveChanges();
            }
        }

        public bool CalculateOverlap(Schedule schedule)
        {
            bool overlapWithSchedule = false;
            foreach (Availability availability in ctx.Availability
                .Where(a => a.EmployeeId == schedule.EmployeeId && a.Type == Availability.AvailabilityType.Ziek)
                .ToList())
            {
                overlapWithSchedule = schedule.StartDate < availability.End && availability.Start < schedule.EndDate;
                if (overlapWithSchedule)
                    break;
            }
            return overlapWithSchedule;
        }

        public List<Availability> GetSickLeave()
        {
            return ctx.Availability
                .Include(a => a.Employee)
                .Where(a => a.Type == Availability.AvailabilityType.Ziek && a.End > DateTime.Now)
                .ToList();
        }
        
        public Employee GetEmployeeByUserId(ClaimsPrincipal currentUser)
        {
            Task<IdentityUser> user = _userManager.FindByNameAsync(currentUser.Identity.Name);
            return ctx.Employees.FirstOrDefault(e => e.userId == user.Result.Id);
        }
    }
}
