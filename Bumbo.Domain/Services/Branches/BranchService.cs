using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Branches
{
    public class BranchService : IBranch
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public BranchService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public List<Branch> GetAll()
        {
            try
            {
                return ctx.Branches.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Branch GetBranch(int id)
        {
            try
            {
                return ctx.Branches.Where(b => b.BranchId == id).Single();
            }
            catch
            {
                return null;
            }
        }

        public Branch Create(Branch model)
        {
            try
            {
                ctx.Branches.Add(model);
                ctx.SaveChanges();
                return model;
            }
            catch
            {
                return null;
            }
        }

        public Branch Update(Branch model)
        {
            try
            {
                ctx.Branches.Attach(model);
                ctx.Branches.Update(model);
                ctx.SaveChanges();
                return model;
            }
            catch
            {
                return null;
            }
        }

        public List<Branch> GetAll(int branchId)
        {
            return ctx.Branches.Where(s => s.BranchId == branchId).ToList();
        }
    }
}
