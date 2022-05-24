using Bumbo.Domain.Models;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.Forecasts
{
    public interface IForecast
    {
        List<Forecast> GetAll();
        Forecast GetOne(int id);
        List<Forecast> GetFuturePrognoses(int branchId);
        void Update(Forecast forecast);
        void Create(Forecast forecast);
        void Recalculate(Forecast forecast);
        int[] GetEmployeeCount(Forecast forecast);
        int GetStockHoursRemaining(int forecastId, Department.DepartmentCode departmentCode);
    }
}
