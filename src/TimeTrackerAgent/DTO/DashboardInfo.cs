using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackerAgent.Entity;

namespace TimeTrackerAgent.DTO
{
    public class DashboardInfo
    {
        public DashboardInfo(Day currentDay)
        {
            WorkingTime = TimeSpan.FromSeconds(currentDay.Applications.Sum(x => x.SummaryTime.TotalSeconds));
            IdleTime = currentDay.Idle;
            TopApplications = currentDay.Applications.OrderByDescending(x => x.SummaryTime).Take(10).ToList();
        }

        public TimeSpan WorkingTime { get; set; }
        public TimeSpan IdleTime { get; set; }
        public List<Application> TopApplications { get; set; }
    }
}
