using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Standards
{
    public class StandardService : IStandard
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public StandardService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public void Create(Standard model)
        {
            try
            {
                ctx.Standards.Add(model);
                ctx.SaveChanges();
            }
            catch
            {

            }
        }

        public void Delete(Standard model)
        {
            try
            {
                ctx.Standards.Remove(model);
                ctx.SaveChanges();
            }
            catch
            {

            }
        }

        public List<Standard> GetAll()
        {
            try
            {
                return ctx.Standards
                    .Include(b => b.Branch)
                    .ToList();
            }
            catch
            {
                return null;
            }

        }

        public List<Standard> GetAll(int branchId)
        {
            return ctx.Standards.Include(b => b.Branch).Where(s => s.BranchId == branchId).ToList();
        }

        public Standard GetStandard(int id)
        {
            try
            {
                return ctx.Standards.Include(b => b.Branch).FirstOrDefault(s => s.StandardId == id);
            }
            catch
            {
                return null;
            }
        }

        public void Update(Standard model)
        {
            try
            {
                ctx.Standards.Attach(model);
                ctx.Standards.Update(model);
                ctx.SaveChanges();
            }
            catch
            {

            }
        }

        public List<Standard> GetDefaultStandards()
        {
            List<Standard> standards = new List<Standard>();

            standards.Add(new Standard()
            {
                Activity = Activity.Coli,
                Norm = 5,
                Description = "Het aantal minuten wat nodig is om een coli uit te laden.",
            });
            standards.Add(new Standard()
            {
                Activity = Activity.Restock,
                Norm = 30,
                Description = "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.",
            });
            standards.Add(new Standard()
            {
                Activity = Activity.Cashout,
                Norm = 30,
                Description = "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.",
            });
            standards.Add(new Standard()
            {
                Activity = Activity.Fresh,
                Norm = 100,
                Description = "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.",
            });
            standards.Add(new Standard()
            {
                Activity = Activity.Mirror,
                Norm = 30,
                Description = "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.",
            });

            return standards;
        }
    }
}
