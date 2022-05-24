using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Contracts
{
    public interface IContract
    {
        List<Contract> GetAll();
    }
}
