using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bumbo.Domain.Services.Contracts
{
    public class ContractService : IContract
    {
        private readonly BumboContext ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public ContractService(UserManager<IdentityUser> userManager, BumboContext context)
        {
            _userManager = userManager;
            ctx = context;
        }

        public List<Contract> GetAll()
        {
            try
            {
                return ctx.Contracts.Include(f => f.Function).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
