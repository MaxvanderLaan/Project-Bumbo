using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Standards
{
    public interface IStandard
    {
        List<Standard> GetAll();
        List<Standard> GetAll(int branchId);
        Standard GetStandard(int id);
        List<Standard> GetDefaultStandards();
        void Create(Standard model);
        void Update(Standard model);
        void Delete(Standard model);
    }
}
