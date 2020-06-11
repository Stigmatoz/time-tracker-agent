﻿using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Utility;

namespace TimeTrackerAgent.DTO
{
    public class DashboardInfo
    {
        public DashboardInfo(Day currentDay)
        {
            WorkingTime = currentDay.ActiveTime;
            IdleTime = currentDay.IdleTime;
            TopApplications = currentDay.Applications.OrderByDescending(x => x.SummaryTime).Take(10).ToList();
            MachineInfo = new LocalMachine(OSHelper.GetOSPlatform(), OSHelper.GetOSDescription());
        }

        public LocalMachine MachineInfo { get; set; }
        public TimeSpan WorkingTime { get; set; }
        public TimeSpan IdleTime { get; set; }
        public List<Application> TopApplications { get; set; }
    }
}
