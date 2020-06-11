using System;
using System.Collections.Generic;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Day
    {
        public Day()
        {
            Date = DateTime.Now;
            IdleTime = TimeSpan.Zero;
            ActiveTime = TimeSpan.Zero;
        }

        public DateTime Date { get; set; }
        public TimeSpan ActiveTime { get; set; }
        public TimeSpan IdleTime { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();

        #region Public
        public void AddApplication(string name, string path, string windowTitle, byte[] array)
        {
            Applications.Add(new Application(name, path, windowTitle, array));
        }

        public void IncrementIdleTime()
        {
            IdleTime = IdleTime.Add(TimeSpan.FromSeconds(1));
        }

        public void IncrementActiveTime()
        {
            ActiveTime = ActiveTime.Add(TimeSpan.FromSeconds(1));
        }
        #endregion
    }
}
