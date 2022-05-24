using System;
using System.Collections.Generic;

namespace Bumbo.Domain.Services.CAO.CAORules
{
    public class DutchCAO : ICAORules
    {
        public int BelowSixteenWorkdayHourLimit { get; set; }
        public int BelowSixteenTimeLimit { get; set; }
        public int BelowSixteenWorkdayLimit { get; set; }
        public int BelowSixteenSchoolWeekHourLimit { get; set; }
        public int BelowSixteenWeekHourLimit { get; set; }
        
        public int BelowEighteenWorkdayHourLimit { get; set; }
        public int BelowEighteenAverageHourLimitPerFourWeeks { get; set; }
        
        public int GeneralWorkdayHourLimit { get; set; }
        public int GeneralWeekHourLimit { get; set; }

        public Surtax EarlyNightShift { get; set; }
        public Surtax LateNightShift { get; set; }
        public Surtax MorningShift { get; set; }
        public Surtax SaturdayShift { get; set; }
        public List<Surtax> Surtaxes { get; set; }

        public DutchCAO()
        {
            this.BelowSixteenWorkdayHourLimit = 8;
            this.BelowSixteenTimeLimit = 19;
            this.BelowSixteenWorkdayLimit = 5;
            this.BelowSixteenSchoolWeekHourLimit = 12;
            this.BelowSixteenWeekHourLimit = 40;

            this.BelowEighteenWorkdayHourLimit = 9;
            this.BelowEighteenAverageHourLimitPerFourWeeks = 40;

            this.GeneralWorkdayHourLimit = 12;
            this.GeneralWeekHourLimit = 60;

            EarlyNightShift = new Surtax() { SurtaxRate = 1.333, StartTime = new TimeSpan(20, 0, 0), EndTime = new TimeSpan(21, 0, 0)};
            LateNightShift = new Surtax() { SurtaxRate = 1.5, StartTime = new TimeSpan(21, 0, 0), EndTime = new TimeSpan(23, 59, 59) };
            MorningShift = new Surtax() { SurtaxRate = 1.5, StartTime = new TimeSpan(0, 0, 0), EndTime = new TimeSpan(6, 0, 0) };
            SaturdayShift = new Surtax() { SurtaxRate = 1.5, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(23, 59, 59), Day = DayOfWeek.Saturday };
            initSurtaxes();
        }

        private void initSurtaxes()
        {
            Surtaxes = new List<Surtax>();
            Surtaxes.Add(MorningShift);
            Surtaxes.Add(EarlyNightShift);
            Surtaxes.Add(LateNightShift);
            Surtaxes.Add(SaturdayShift);
        }
    }
}