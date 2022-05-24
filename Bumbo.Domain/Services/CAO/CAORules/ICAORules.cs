using System;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.CAO.CAORules
{
    public interface ICAORules
    {
        int BelowSixteenWorkdayHourLimit { get; set; }
        int BelowSixteenTimeLimit { get; set; }
        int BelowSixteenWorkdayLimit { get; set; }
        int BelowSixteenSchoolWeekHourLimit { get; set; }
        int BelowSixteenWeekHourLimit { get; set; }

        int BelowEighteenWorkdayHourLimit { get; set; }
        int BelowEighteenAverageHourLimitPerFourWeeks { get; set; }

        int GeneralWorkdayHourLimit { get; set; }
        int GeneralWeekHourLimit { get; set; }

        public List<Surtax> Surtaxes { get; set; }
        public Surtax EarlyNightShift { get; set; }
        public Surtax LateNightShift { get; set; }
        public Surtax MorningShift { get; set; }
        public Surtax SaturdayShift { get; set; }
    }
}