using Bumbo.Domain.Models;
using Bumbo.Domain.Services.CAO.CAORules;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nager.Date;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Bumbo.Domain.Services.Remunerations
{
    public class RemunerationService : IRemuneration
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;
        private ICAORules _caoRules { get; set; }

        public RemunerationService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _caoRules = new DutchCAO();
            _userManager = userManager;
            ctx = context;
        }

        public void Approve(Remuneration model)
        {
            try
            {
                ctx.Attach(model);
                ctx.Remunerations.Update(model);
                ctx.SaveChanges();
            }
            catch
            {

            }
        }

        public void Create(DateTime startDate, DateTime endDate, Employee employee, bool isSick)
        {
            Remuneration model = new Remuneration();
            model.Employee = employee;
            model.EmployeeId = employee.EmployeeId;
            model.Date = startDate;
            model.IsApproved = false;
            TimeSpan hoursWorked = new TimeSpan(endDate.Hour - startDate.Hour, endDate.Minute - startDate.Minute, endDate.Second - startDate.Second);
            model.Hours = hoursWorked;

            double surtaxresult = 0;
            double oldHoursWorked = ((model.Hours.Value.Hours * 60) + model.Hours.Value.Minutes);
            oldHoursWorked = oldHoursWorked / 60;
            if (DateSystem.IsPublicHoliday(startDate, "NL") || startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                surtaxresult = 100;
            }
            else
            {
                foreach (Surtax surtax in _caoRules.Surtaxes)
                {
                    if (surtax.Day != null && startDate.DayOfWeek == surtax.Day || surtax.Day == null)
                    {
                        double newVal = 0;
                        if (startDate.Hour <= surtax.StartTime.Hours && endDate.Hour >= surtax.EndTime.Hours)
                        {
                            newVal += (surtax.EndTime.Hours - surtax.StartTime.Hours) * 60 + surtax.EndTime.Minutes;
                            newVal = newVal / 60;
                        }
                        else if (startDate.Hour >= surtax.StartTime.Hours && startDate.Hour <= surtax.EndTime.Hours && endDate.Hour >= surtax.EndTime.Hours) 
                        {
                            newVal += ((surtax.EndTime.Hours - startDate.Hour) * 60) + surtax.EndTime.Minutes;
                            newVal = newVal / 60;
                        }
                        else if (startDate.Hour <= surtax.StartTime.Hours && endDate.Hour <= surtax.EndTime.Hours && endDate.Hour >= surtax.StartTime.Hours)
                        {
                            newVal += ((surtax.EndTime.Hours - endDate.Hour) * 60) + surtax.EndTime.Minutes;
                            newVal = newVal / 60;
                        }
                        else if (startDate.Hour >= surtax.StartTime.Hours && startDate.Hour <= surtax.EndTime.Hours && endDate.Hour >= surtax.StartTime.Hours && endDate.Hour <= surtax.EndTime.Hours)
                        {
                            newVal += ((endDate.Hour - startDate.Hour) * 60) + (endDate.Minute - startDate.Minute);
                            newVal = newVal / 60;
                        }
                        if (newVal > 0)
                        {
                            oldHoursWorked -= newVal;
                            newVal = newVal * surtax.SurtaxRate;
                            surtaxresult += newVal;
                        }
                    }
                }
                if (surtaxresult > 0)
                {
                    surtaxresult += oldHoursWorked;
                    if(isSick)
                    {
                        surtaxresult = surtaxresult * 0.7;
                    }
                    double old = ((model.Hours.Value.Hours * 60) + model.Hours.Value.Minutes);
                    old = old / 60;
                    surtaxresult = (surtaxresult - old) / old * 100;
                }
            }
            model.SurtaxRate = Math.Round(surtaxresult, 2);

            ctx.Remunerations.Add(model);
            ctx.SaveChanges();
        }

        public List<Remuneration> Filter(Remuneration filterData, int branchId, string year, string weeknr)
        {
            try
            {
                List<Remuneration> results = new List<Remuneration>();
                IEnumerable<Remuneration> remunerations = ctx.Remunerations.Include(r => r.Employee).ToList();
                if (filterData != null)
                {
                    if (filterData.Employee.FirstName != null)
                        remunerations = remunerations.Where(r => r.Employee.FirstName.ToLower().Contains(filterData.Employee.FirstName.ToLower())).ToList();
                    if (filterData.Employee.MiddleName != null)
                        remunerations = remunerations.Where(r => r.Employee.MiddleName.ToLower().Contains(filterData.Employee.MiddleName.ToLower())).ToList();
                    if (filterData.Employee.LastName != null)
                        remunerations = remunerations.Where(r => r.Employee.LastName.ToLower().Contains(filterData.Employee.LastName.ToLower())).ToList();
                    if (branchId != 0)
                        remunerations = remunerations.Where(r => r.Employee.BranchId.Equals(branchId)).ToList();
                    if (year != null)
                    {
                        DateTime dtYear = new DateTime(int.Parse(year), 1, 1);
                        remunerations = remunerations.Where(r => r.Date.Year.Equals(dtYear.Year)).ToList();
                    }
                    if (weeknr != null)
                    {
                        List<Remuneration> remunerationsDate = new List<Remuneration>();
                        foreach (Remuneration item in remunerations)
                        {
                            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                            Calendar cal = dfi.Calendar;
                            int itemWeeknr = cal.GetWeekOfYear(item.Date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                            if (int.Parse(weeknr) == cal.GetWeekOfYear(item.Date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))
                                remunerationsDate.Add(item);
                        }
                        remunerations = remunerationsDate;
                    }
                    remunerations = filterData.IsApproved == true ? remunerations.Where(r => r.IsApproved == true).ToList() : remunerations.Where(r => r.IsApproved == false).ToList();
                }
                results = remunerations.OrderBy(r => r.Date).ToList();
                return results;
            }
            catch
            {
                return null;
            }
        }

        public void Edit(Remuneration model)
        {
            ctx.Remunerations.Attach(model);
            ctx.Remunerations.Update(model);
            ctx.SaveChanges();
        }

        public Remuneration FindRemuneration(int id)
        {
            try
            {
                Remuneration remuneration = ctx.Remunerations.Where(r => r.RenumerationId == id).First();
                remuneration.IsApproved = true;
                return remuneration;
            }
            catch
            {
                return null;
            }
        }

        public List<Remuneration> GetAll()
        {
            try
            {
                List<Remuneration> results = new List<Remuneration>();
                results = ctx.Remunerations
                    .Include(r => r.Employee)
                    .ThenInclude(e => e.Branch)
                    .OrderBy(r => r.Date)
                    .Where(r => r.IsApproved == false)
                    .ToList();
                return results;
            }
            catch
            {
                return null;
            }
        }

        public List<Remuneration> GetRemunerations(int year, int month, int day)
        {
            try
            {
                if (year == 0 && month == 0 && day == 0)
                {
                    return ctx.Remunerations.Include("Employee").ToList();
                }
                else if (year != 0 && month == 0 && day == 0)
                {
                    return ctx.Remunerations.Where(r => r.Date.Year == year).Include("Employee").ToList();
                }
                else if (year != 0 && month != 0 && day == 0)
                {
                    return ctx.Remunerations.Where(r => r.Date.Year == year && r.Date.Month == month).Include("Employee").ToList();
                }
                else if (year != 0 && month != 0 && day != 0)
                {
                    return ctx.Remunerations.Where(r => r.Date.Year == year && r.Date.Month == month && r.Date.Day == day).Include("Employee").ToList();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void Delete(Remuneration model)
        {
            if (model != null)
            {
                ctx.Remunerations.Remove(model);
                ctx.SaveChanges();
            }
        }

        public List<Remuneration> GetAll(int branchId)
        {
            return ctx.Remunerations.Include(e => e.Employee).Where(r => r.Employee.Branch.BranchId == branchId).ToList();
        }

        public Remuneration GetRemuneration(int remunerationId)
        {
            return ctx.Remunerations.Include(r => r.Employee).FirstOrDefault(r => r.RenumerationId == remunerationId);
        }
    }
}
