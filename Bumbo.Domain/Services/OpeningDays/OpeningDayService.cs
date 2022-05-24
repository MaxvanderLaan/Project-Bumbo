using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.OpeningDays
{
    public class OpeningDayService : IOpeningDay
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public OpeningDayService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public void Create(int branchId, List<OpeningDay> openingDays)
        {
            try
            {
                foreach (OpeningDay openingDay in openingDays)
                {
                    openingDay.BranchId = branchId;
                    ctx.OpeningDays.Add(openingDay);
                }
                ctx.SaveChanges();
            }
            catch 
            {

            }
        }

        public void Update(int branchId, List<OpeningDay> openingDays)
        {
            try
            {
                foreach (OpeningDay openingDay in openingDays)
                {
                    openingDay.BranchId = branchId;
                    ctx.OpeningDays.Attach(openingDay);
                    ctx.OpeningDays.Update(openingDay);
                }
                ctx.SaveChanges();
            }
            catch 
            {

            }
        }

        public OpeningDay GetOpeningDay(int id, DayOfWeek dayOfWeek)
        {
            try
            {
                return ctx.OpeningDays.FirstOrDefault(o => o.BranchId == id && o.DayOfWeek == dayOfWeek);
            }
            catch 
            {
                return null;
            }
        }

    }
}
