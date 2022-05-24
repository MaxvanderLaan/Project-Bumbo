using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.OpeningDays
{
    public interface IOpeningDay
    {
        OpeningDay GetOpeningDay(int id, DayOfWeek dayOfWeek);
        void Create(int branchId, List<OpeningDay> openingDays);
        void Update(int branchId, List<OpeningDay> openingsDays);
    }
}
