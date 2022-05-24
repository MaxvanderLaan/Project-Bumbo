using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Functions
{
    public interface IFunction
    {
        List<Function> GetAll();
        Function GetFunction(int functionId);
        void Create(Function model);
        void Update(Function model);
        void Delete(Function model);
    }
}
