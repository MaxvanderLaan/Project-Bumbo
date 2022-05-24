using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bumbo.Domain.Models;
using Bumbo.Domain.Services.CAO.CAORules;

namespace Bumbo.Domain.Services.CAO
{
    public class CAOService : ICAO
    {
        private readonly BumboContext ctx;
        private ICAORules _caoRules { get; set; }

        public CAOService(BumboContext context)
        {
            ctx = context;
        }
        public ICAORules GetDutchCAO()
        {
            _caoRules = new DutchCAO();
            return _caoRules;
        }
        
        public DateTime GetWorkHoursOfDay(int employeeId, int scheduleId, DateTime startDate, DateTime endDate)
        {
            DateTime result = new DateTime();
            List<Schedule> schedules = GetEmployeeSchedulesExclude(employeeId, scheduleId).Where(s =>
                s.StartDate.Date == startDate.Date || s.EndDate.Date == startDate.Date).ToList();

            if (schedules != null)
            {
                foreach (Schedule sch in schedules.Where(s => s.StartDate.Date < startDate.Date))
                    result = result.AddHours(sch.EndDate.Hour).AddMinutes(sch.EndDate.Minute);

                foreach (Schedule sch in schedules.Where(s => s.EndDate.Date > startDate.Date))
                {
                    result = result.AddHours(24 - sch.StartDate.Hour);
                    if (sch.StartDate.Minute > 0)
                        result = result.AddMinutes(60 - sch.StartDate.Minute).AddHours(-1);
                }

                foreach (Schedule sch in schedules.Where(s =>
                    s.StartDate.Date == startDate.Date && s.EndDate.Date == startDate.Date))
                    result = result.AddHours(sch.EndDate.Hour - sch.StartDate.Hour).AddMinutes(sch.EndDate.Minute - sch.StartDate.Minute);
            }
            
            result = result.Add(endDate - startDate);
            return result;
        }

        public DateTime GetSchoolHoursOfDay(int employeeId, DateTime day)
        {
            DateTime result = new DateTime();

            foreach (Availability schoolAv in ctx.Availability.Where(a => a.Start.Date == day.Date && a.Type == Availability.AvailabilityType.School && a.EmployeeId == employeeId).ToList())
                result = result.AddHours(schoolAv.End.Hour - schoolAv.Start.Hour).AddMinutes(schoolAv.End.Minute - schoolAv.Start.Minute);

            return result;
        }

        public bool GetSchoolWeek(int employeeId, DateTime day)
        {
            Calendar calendar = new GregorianCalendar();
            int weekIndex = calendar.GetWeekOfYear(day, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            bool schoolweek = false;
            foreach (Availability availability in ctx.Availability.Where(a => a.EmployeeId == employeeId && a.Type == Availability.AvailabilityType.School))
            {
                if (calendar.GetWeekOfYear(availability.Start, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) ==
                    weekIndex)
                {
                    schoolweek = true;
                    break;
                }
            }
            return schoolweek;
        }

        public DateTime GetWeekTotal(int employeeId, int scheduleId, DateTime startDate, DateTime endDate)
        {
            DateTime result = new DateTime();

            foreach (DateTime dayOfWeek in GetWeekDates(startDate))
            {
                result = result.Add(GetWorkHoursOfDay(employeeId, scheduleId, dayOfWeek, dayOfWeek).TimeOfDay);
            }
            
            result = result.Add(endDate - startDate);
            return result;
        }

        public int CountWorkingDays(int employeeId, int scheduleId, DateTime startDate, DateTime endDate)
        {
            List<DateTime> uniqueDays = new List<DateTime>();
            List<DateTime> weekDates = GetWeekDates(startDate);

            foreach (Schedule schedule in GetEmployeeSchedulesExclude(employeeId, scheduleId)
                .Where(s => weekDates.Contains(s.StartDate.Date)))
                if (!uniqueDays.Contains(schedule.StartDate.Date)) uniqueDays.Add(schedule.StartDate.Date);
            
            if (!uniqueDays.Contains(startDate.Date)) uniqueDays.Add(startDate.Date);
            return uniqueDays.Count;
        }

        public List<DateTime> GetWeekDates(DateTime date)
        {
            List<DateTime> dates = new List<DateTime>();
            int dayOfWeek = (int) date.DayOfWeek;

            if (dayOfWeek == 0)
            {
                for (int i = 0; i > -7; i--)
                    dates.Add(date.Date.AddDays(i));
            }
            else
            {
                for (int i = dayOfWeek; i > 0; i--)
                    dates.Add(date.Date.AddDays(1 - i));

                for (int i = 1; i <= (7 - dayOfWeek); i++)
                    dates.Add(date.Date.AddDays(i));
            }
            return dates;
        }

        public List<Schedule> GetEmployeeSchedulesExclude(int employeeId, int scheduleId)
        {
            return ctx.Schedules.Where(s => s.ScheduleId != scheduleId && s.EmployeeId == employeeId).ToList();
        }
    }
}