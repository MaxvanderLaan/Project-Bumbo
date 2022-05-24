using System;
using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Remunerations
{
    public interface IRemuneration
    {
        List<Remuneration> Filter(Remuneration filterData, int branchId, string year, string weeknr);
        List<Remuneration> GetAll();
        List<Remuneration> GetAll(int branchId);
        Remuneration GetRemuneration(int remunerationId);
        Remuneration FindRemuneration(int id);
        List<Remuneration> GetRemunerations(int year, int month, int day);
        void Approve(Remuneration model);
        void Create(DateTime startTime, DateTime endTime, Employee employee, bool isSick);
        void Delete(Remuneration model);
        void Edit(Remuneration model);
    }
}
