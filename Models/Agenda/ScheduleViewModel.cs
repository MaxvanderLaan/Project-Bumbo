using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bumbo.Domain.Models;
using Bumbo.Domain.Services.CAO;
using Bumbo.Domain.Services.CAO.CAORules;
using Bumbo.Domain.Services.Schedules;
using Microsoft.Extensions.DependencyInjection;

namespace Bumbo.Web.Models.Agenda
{
    public class ScheduleViewModel : IValidatableObject
    {
        public Schedule Schedule { get; set; }
        public List<Availability> Availabilities { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Schedule.EmployeeId != 0)
            {
                ISchedule scheduleService = validationContext.GetService<ISchedule>();
                ICAO caoService = validationContext.GetService<ICAO>();

                if (Schedule.StartDate > Schedule.EndDate)
                    yield return new ValidationResult("De startdatum kan niet na de einddatum vallen.");

                if (Schedule.StartDate == Schedule.EndDate)
                    yield return new ValidationResult("Deze dienst bevat geen looptijd.");

                if (Schedule.StartDate < DateTime.Now)
                    yield return new ValidationResult("De startdatum kan niet in het verleden vallen.");

                if (Schedule.EndDate < DateTime.Now)
                    yield return new ValidationResult("De einddatum kan niet in het verleden vallen.");

                if (scheduleService != null)
                {
                    if (checkOverlapAvailability(scheduleService))
                        yield return new ValidationResult(
                            "Deze medewerker is gemarkeerd als onbeschikbaar gedurende deze periode.");

                    if (checkOverlapSchedule(scheduleService))
                        yield return new ValidationResult("Deze medewerker is al ingeroosterd gedurende deze periode.");

                    if (scheduleService.GetEmployee(Schedule.EmployeeId).Departments
                        .All(d => d.DepartmentId != Schedule.DepartmentId))
                        yield return new ValidationResult("Deze medewerker kan niet op deze afdeling werken.");
                }

                if (caoService != null && Schedule.StartDate < Schedule.EndDate)
                {
                    ICAORules caoRules = caoService.GetDutchCAO();
                    int age = getAge(scheduleService.GetEmployee(Schedule.EmployeeId).BirthDate);

                    if (Schedule.StartDate.Date == Schedule.EndDate.Date)
                    {
                        if (age < 16)
                        {
                            IEnumerable<ValidationResult> validationResults =
                                underSixteenValidation(caoRules, caoService);
                            foreach (ValidationResult val in validationResults)
                                yield return val;
                        }
                        else if (age < 18)
                        {
                            IEnumerable<ValidationResult> validationResults =
                                underEighteenValidation(caoRules, caoService);
                            foreach (ValidationResult val in validationResults)
                                yield return val;
                        }
                        else
                        {
                            IEnumerable<ValidationResult>
                                validationResults = generalAgeValidation(caoRules, caoService);
                            foreach (ValidationResult val in validationResults)
                                yield return val;
                        }
                    }
                    else yield return new ValidationResult("Een dienst mag maar tot 23:59 duren.");
                }
            }
            else yield return new ValidationResult("Vul een medewerker in.");
        }

        private bool checkOverlapAvailability(ISchedule scheduleService)
        {
            return scheduleService.GetAvailabilityOverlap(Schedule.EmployeeId, Schedule.StartDate, Schedule.EndDate);
        }

        private bool checkOverlapSchedule(ISchedule scheduleService)
        {
            return scheduleService.GetScheduleOverlapExclude(Schedule.EmployeeId, Schedule.ScheduleId, Schedule.StartDate, Schedule.EndDate);
        }

        private IEnumerable<ValidationResult> underSixteenValidation(ICAORules caoRules, ICAO caoService)
        {
            if (checkTimeLimit(caoRules.BelowSixteenTimeLimit))
                yield return new ValidationResult(
                    $"Deze werknemer is jonger dan 16 en mag niet na {caoRules.BelowSixteenTimeLimit}:00 werken.");

            if (checkSchoolAndWorkHourLimit(caoService.GetWorkHoursOfDay(Schedule.EmployeeId,
                    Schedule.ScheduleId,
                    Schedule.StartDate, Schedule.EndDate),
                caoService.GetSchoolHoursOfDay(Schedule.EmployeeId, Schedule.StartDate),
                caoRules.BelowSixteenWorkdayHourLimit))
                yield return new ValidationResult(
                    $"Deze werknemer is jonger dan 16 en mag niet langer dan {caoRules.BelowSixteenWorkdayHourLimit} uur per dag met school en werk bezig zijn.");

            DateTime weekResult = caoService.GetWeekTotal(Schedule.EmployeeId, Schedule.ScheduleId,
                Schedule.StartDate, Schedule.EndDate);
            if (caoService.GetSchoolWeek(Schedule.EmployeeId, Schedule.StartDate))
            {
                if (checkSchoolWeekHourLimit(weekResult, caoRules.BelowSixteenSchoolWeekHourLimit))
                    yield return new ValidationResult(
                        $"Deze werknemer is jonger dan 16 en mag niet meer dan {caoRules.BelowSixteenSchoolWeekHourLimit} uur werken in een schoolweek.");
            }
            else
            {
                if (checkWeekHourLimit(weekResult, caoRules.BelowSixteenWeekHourLimit))
                    yield return new ValidationResult(
                        $"Deze werknemer is jonger dan 16 en mag niet meer dan {caoRules.BelowSixteenWeekHourLimit} uur werken in een week.");
            }

            if (caoService.CountWorkingDays(Schedule.EmployeeId, Schedule.ScheduleId, Schedule.StartDate,
                Schedule.EndDate) > caoRules.BelowSixteenWorkdayLimit)
                yield return new ValidationResult(
                    $"Deze werknemer is jonger dan 16 en mag niet op meer dan {caoRules.BelowSixteenWorkdayLimit} dagen werken in een week.");
        }

        private IEnumerable<ValidationResult> underEighteenValidation(ICAORules caoRules, ICAO caoService)
        {
            if (checkSchoolAndWorkHourLimit(caoService.GetWorkHoursOfDay(Schedule.EmployeeId,
                        Schedule.ScheduleId,
                        Schedule.StartDate, Schedule.EndDate),
                    caoService.GetSchoolHoursOfDay(Schedule.EmployeeId, Schedule.StartDate),
                    caoRules.BelowEighteenWorkdayHourLimit))
                    yield return new ValidationResult(
                        $"Deze werknemer is jonger dan 18 en mag niet langer dan {caoRules.BelowEighteenWorkdayHourLimit} uur per dag met school en werk bezig zijn.");
       
            DateTime weekResult = caoService.GetWeekTotal(Schedule.EmployeeId, Schedule.ScheduleId,
                Schedule.StartDate, Schedule.EndDate);
            if (checkWeekHourLimit(weekResult, caoRules.GeneralWeekHourLimit))
                yield return new ValidationResult(
                    $"Deze werknemer mag niet meer dan {caoRules.GeneralWeekHourLimit} uur werken in een week.");
            
            if (checkFourWeekAverage(caoService, caoRules))
                yield return new ValidationResult(
                    $"Deze werknemer is jonger dan 18 en mag niet meer dan {caoRules.BelowEighteenAverageHourLimitPerFourWeeks} uur werken gemiddeld over 4 weken.");
        }
        
        private IEnumerable<ValidationResult> generalAgeValidation(ICAORules caoRules, ICAO caoService)
        {
            if (checkAdultDayHourLimit(caoService.GetWorkHoursOfDay(Schedule.EmployeeId, Schedule.ScheduleId,
                Schedule.StartDate, Schedule.EndDate), caoRules.GeneralWorkdayHourLimit))
                yield return new ValidationResult(
                    $"Deze werknemer mag niet meer dan {caoRules.GeneralWorkdayHourLimit} uur ingepland staan op een dag.");
            
            DateTime weekResult = caoService.GetWeekTotal(Schedule.EmployeeId, Schedule.ScheduleId,
                Schedule.StartDate, Schedule.EndDate);

            if (checkWeekHourLimit(weekResult, caoRules.GeneralWeekHourLimit))
                yield return new ValidationResult(
                    $"Deze werknemer mag niet meer dan {caoRules.GeneralWeekHourLimit} uur werken in een week.");
        }

        private bool checkTimeLimit(int limit)
        {
            if (Schedule.EndDate.Hour > limit || (Schedule.EndDate.Hour == limit && Schedule.EndDate.Minute > 0))
                return true;
            return false;
        }

        private bool checkSchoolAndWorkHourLimit(DateTime result, DateTime schoolHours, int limit)
        {
            result = result.AddHours(schoolHours.Hour).AddMinutes(schoolHours.Minute);

            if (schoolHours.Day > 1)
                result = result.AddDays(schoolHours.Day - 1);

            if (result.Day > 1
                || result.Hour > limit
                || (result.Hour == limit && result.Minute > 0))
                return true;
            return false;
        }

        private bool checkSchoolWeekHourLimit(DateTime weekResult, int limit)
        {
            if (weekResult.Hour > limit
                || (weekResult.Hour == limit && weekResult.Minute > 0)
                || weekResult.Day > 1)
                return true;
            return false;
        }

        private bool checkWeekHourLimit(DateTime weekResult, int limit)
        {
            int weekHours = dateTimeGetHours(weekResult);
            if (weekHours > limit ||
                (weekHours == limit && weekResult.Minute > 0))
                return true;
            return false;
        }

        private bool checkAdultDayHourLimit(DateTime result, int limit)
        {
            int hourSum = dateTimeGetHours(result);
            if (hourSum > limit || (hourSum == limit && result.Minute > 0))
                return true;
            return false;
        }

        private int dateTimeGetHours(DateTime dateTime)
        {
            int hours = dateTime.Hour;
            for (int i = 1; i < dateTime.Day; i++)
                hours = hours + 24;
            return hours;
        }

        private int getAge(DateTime birthDate)
        {
            DateTime ageDate = new DateTime();
            return ageDate.Add(DateTime.Today - birthDate).Year - 1;
        }

        private bool checkFourWeekAverage(ICAO caoService, ICAORules caoRules)
        {
            int numberOfDaysInWeek = 7;
            int currentIndex = 0;
            int midOfWeekIndex = 3;
            int numberOfWeekAverage = 4;
            DateTime[] dateTimes = new DateTime[7];

            dateTimes[midOfWeekIndex] = caoService.GetWeekTotal(Schedule.EmployeeId, Schedule.ScheduleId, Schedule.StartDate, Schedule.EndDate);
            
            for (int i = numberOfDaysInWeek; currentIndex < midOfWeekIndex; i = i + numberOfDaysInWeek)
            {
                dateTimes[midOfWeekIndex - (currentIndex + 1)] = caoService.GetWeekTotal(Schedule.EmployeeId, Schedule.ScheduleId,
                    Schedule.StartDate.AddDays(-i).Date, Schedule.EndDate.AddDays(-i).Date);
                
                dateTimes[currentIndex + (midOfWeekIndex + 1)] = caoService.GetWeekTotal(Schedule.EmployeeId, Schedule.ScheduleId,
                    Schedule.StartDate.AddDays(i).Date, Schedule.EndDate.AddDays(i).Date);
                currentIndex++;
            }

            for (int i = 0; i < numberOfWeekAverage; i++)
            {
                double minutes = 0;
                double hours = 0;
                for (int o = 0; o < numberOfWeekAverage; o++)
                {
                    if (dateTimes[i + o].Minute > 0)
                        minutes = minutes + dateTimes[i + o].Minute;
                    hours = hours + dateTimeGetHours(dateTimes[i + o]);
                    for (; minutes > 60; minutes = minutes - 60)
                        hours++;
                }

                if (hours > 0)
                    hours = hours / numberOfWeekAverage;
                if (minutes > 0)
                    minutes = minutes / numberOfWeekAverage;
                if (hours > caoRules.BelowEighteenAverageHourLimitPerFourWeeks || (hours == caoRules.BelowEighteenAverageHourLimitPerFourWeeks && minutes > 0))
                    return true;
            }
            return false;
        }
    }
}