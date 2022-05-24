using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Functions
{
    public class FunctionService : IFunction
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public FunctionService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public List<Function> GetAll()
        {
            List<Function> shit = ctx.Functions.Include(d => d.Department).ToList();
            return ctx.Functions.Include(d => d.Department).ToList();
        }

        public Function GetFunction(int functionId)
        {
            try
            {
                return ctx.Functions.Include(d => d.Department).FirstOrDefault(f => f.FunctionId == functionId);
            }
            catch 
            {
                return null;
            }
        }

        public void Create(Function model)
        {
            try
            {
                ctx.Functions.Add(model);
                ctx.SaveChanges();
            }
            catch 
            {

            }
        }

        public void Update(Function model)
        {
            try
            {
                ctx.Functions.Attach(model);
                ctx.Functions.Update(model);
                ctx.SaveChanges();
            }
            catch 
            {

            }
        }

        public void Delete(Function model)
        {
            try
            {
                ctx.Functions.Remove(model);
                ctx.SaveChanges();
            }
            catch 
            {

            }
        }
    }
}
