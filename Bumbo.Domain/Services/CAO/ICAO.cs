using System;
using System.Collections.Generic;
using Bumbo.Domain.Models;
using Bumbo.Domain.Services.CAO.CAORules;

namespace Bumbo.Domain.Services.CAO
{
    public interface ICAO
    {
        ICAORules GetDutchCAO();
        DateTime GetWorkHoursOfDay (int employeeId, int scheduleId, DateTime startDate, DateTime endDate);
        DateTime GetSchoolHoursOfDay(int employeeId, DateTime day);
        bool GetSchoolWeek(int employeeId, DateTime day);
        DateTime GetWeekTotal(int employeeId, int scheduleId, DateTime startDate, DateTime endDate);
        int CountWorkingDays(int employeeId, int scheduleId, DateTime startDate, DateTime endDate);
        List<DateTime> GetWeekDates(DateTime date);
        List<Schedule> GetEmployeeSchedulesExclude(int employeeId, int scheduleId);
    }
}