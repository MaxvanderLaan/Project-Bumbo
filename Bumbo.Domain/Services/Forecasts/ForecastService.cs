using System;
using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Forecasts
{
    public class ForecastService : IForecast
    {
        private readonly UserManager<IdentityUser> _userManager;
        private static BumboContext Ctx;

        public ForecastService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            Ctx = context;
        }

        public List<Forecast> GetAll()
        {
            return Ctx.Forecasts.Include(b => b.Branch).ToList();
        }

        public List<Forecast> GetFuturePrognoses(int branchId)
        {
            return Ctx.Forecasts.Include(b => b.Branch).Where(f => f.BranchId == branchId && f.Date >= DateTime.Today).ToList();
        }

        public Forecast GetOne(int id)
        {
            return Ctx.Forecasts.Include(f => f.Branch).FirstOrDefault(f => f.ForecastId == id);
        }

        public void Update(Forecast forecast)
        {
            Ctx.Attach(forecast);
            Ctx.Forecasts.Update(forecast);
            Ctx.SaveChanges();
        }

        public void Create(Forecast forecast)
        {
            int[] employeesNeeded = GetEmployeeCount(forecast);
            forecast.AmountOfStockClerks = employeesNeeded[0];
            forecast.AmountOfCashiers = employeesNeeded[1];
            forecast.AmountOfFresh = employeesNeeded[2];
            
            Ctx.Forecasts.Add(forecast);
            Ctx.SaveChanges();
        }

        public void Recalculate(Forecast forecast)
        {
            int[] employeesNeeded = GetEmployeeCount(forecast);
            forecast.AmountOfStockClerks = employeesNeeded[0];
            forecast.AmountOfCashiers = employeesNeeded[1];
            forecast.AmountOfFresh = employeesNeeded[2];

            Ctx.Forecasts.Update(forecast);
            Ctx.SaveChanges();
        }

        private int getAmountOfStockers(Forecast forecast)
        {
            int timePerColli = Ctx.Standards.FirstOrDefault(b => b.BranchId == forecast.BranchId && b.Activity == Activity.Restock).Norm;
            int timeForMirror = Ctx.Standards.FirstOrDefault(b => b.BranchId == forecast.BranchId && b.Activity == Activity.Mirror).Norm;
            int timeForUnloading = Ctx.Standards.FirstOrDefault(b => b.BranchId == forecast.BranchId && b.Activity == Activity.Coli).Norm;

            int mirrorMinutes = (int)(Math.Ceiling((double)(timeForMirror * forecast.Branch.ShelvesLength) / 60));
            int minutesNecessary = forecast.RollContainers * timePerColli;
            minutesNecessary = minutesNecessary + mirrorMinutes + (timeForUnloading * forecast.RollContainers);

            return (int)(Math.Ceiling((double)(minutesNecessary / 60)));
        }

        private int getAmountOfCashiers(Forecast forecast)
        {
            int customersPerHourPerCashier = Ctx.Standards.FirstOrDefault(b => b.BranchId == forecast.BranchId && b.Activity == Activity.Cashout).Norm;
            double amountOfMinutes = (forecast.AmountOfCustomers / customersPerHourPerCashier) * 60;
               
            return (int)(Math.Ceiling((double)(amountOfMinutes / 60)));
        }

        private int getAmountOfFresh(Forecast forecast)
        {
            int customersPerHourPerEmployee = Ctx.Standards.FirstOrDefault(b => b.BranchId == forecast.BranchId && b.Activity == Activity.Fresh).Norm;
            double amountOfMinutes = (forecast.AmountOfCustomers / customersPerHourPerEmployee) * 60;

            return (int)(Math.Ceiling((double)(amountOfMinutes / 60)));
        }

        public int[] GetEmployeeCount(Forecast forecast)
        {
            int[] totalEmployees = new int[3];

            Branch branch = Ctx.Branches.Include(b => b.OpeningDays).FirstOrDefault(b => b.BranchId == forecast.BranchId);
            forecast.Branch = branch;
            
            totalEmployees[0] = getAmountOfStockers(forecast);
            totalEmployees[1] = getAmountOfCashiers(forecast);
            totalEmployees[2] = getAmountOfFresh(forecast);

            return totalEmployees; 
        }

        public int GetStockHoursRemaining(int forecastId, Department.DepartmentCode departmentCode)
        {
            TimeSpan firstBreak = new TimeSpan(4, 30, 0);
            TimeSpan secondBreak = new TimeSpan(8, 0, 0);
            TimeSpan breakLength = new TimeSpan(0, 30, 0);
            Forecast forecast = Ctx.Forecasts.FirstOrDefault(f => f.ForecastId == forecastId);
            List<Schedule> schedules = Ctx.Schedules
                .Include(s => s.Department)
                .Where(s => s.StartDate.Date == forecast.Date.Date 
                            && s.Department.Code == departmentCode)
                .ToList();

            TimeSpan total = new TimeSpan();
            foreach (Schedule schedule in schedules)
            {
                TimeSpan timeDiffrence = schedule.EndDate - schedule.StartDate;
                total = total.Add(timeDiffrence);
                if (timeDiffrence >= firstBreak)
                    total = total.Subtract(breakLength);
                if (timeDiffrence >= secondBreak)
                    total = total.Subtract(breakLength);
            }
            
            if (departmentCode == Department.DepartmentCode.VAK)
                return (int)Math.Ceiling((double)(forecast.AmountOfStockClerks - total.TotalHours));
            else if (departmentCode == Department.DepartmentCode.KAS)
                return (int)Math.Ceiling((double)(forecast.AmountOfCashiers - total.TotalHours));
            else 
                return (int)Math.Ceiling((double)(forecast.AmountOfFresh - total.TotalHours));
        }
    }
}
