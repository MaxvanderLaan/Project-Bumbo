using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Bumbo.Domain.Services.Schedules
{
    public interface ISchedule
    {
        void AddSchedule(Schedule schedule);
        List<Schedule> GetAllSchedules();
        Schedule GetSchedule(int id);
        bool GetScheduleOverlap(int employeeId, DateTime startDate, DateTime endDate);
        bool GetScheduleOverlapExclude(int employeeId, int scheduleId, DateTime startDate, DateTime endDate);
        List<Schedule> GetEmployeeSchedule(int id);
        List<Schedule> GetEmployeePeriodSchedule(int employeeId, DateTime startDate, DateTime endDate);
        bool GetAvailabilityOverlapExclude(int employeeId, int availabilityId, DateTime startDate, DateTime endDate);
        bool GetAvailabilityOverlap(int employeeid, DateTime startDate, DateTime endDate);
        List<Availability> GetEmployeeFutureAvailability(int id);
        Availability GetAvailability(int id);
        Availability AddAvailability(Availability availability);
        Availability UpdateAvailability(Availability availability);
        Availability DeleteAvailability(int id);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
        List<Department> GetDepartments();
        List<Employee> GetAvailableEmployees();
        List<Employee> GetSchedulableEmployees(int branchId);
        List<Availability> GetUnapprovedAvailabilities();
        List<Availability> GetApprovedAvailabilities();
        Employee GetEmployee(int employeeId);
        void Approve(int id);
        void Disapprove(int id);
        void PublishSchedule(DateTime startDate, DateTime endDate);
        bool CalculateOverlap(Schedule schedule);
        List<Availability> GetSickLeave();
        Employee GetEmployeeByUserId(ClaimsPrincipal currentUser);
    }
}
