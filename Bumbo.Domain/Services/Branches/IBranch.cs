using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Branches
{
    public interface IBranch
    {
        Branch GetBranch(int id);
        List<Branch> GetAll();
        List<Branch> GetAll(int branchId);
        Branch Update(Branch model);
        Branch Create(Branch model);
    }
}
