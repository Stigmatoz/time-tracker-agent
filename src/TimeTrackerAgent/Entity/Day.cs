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
            Idle = TimeSpan.Zero;
        }

        public DateTime Date { get; set; }
        public TimeSpan Idle { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();

        #region Public
        public void AddApplication(string name, string path, string windowTitle, byte[] array)
        {
            Applications.Add(new Application(name, path, windowTitle, array));
        }

        public void IncrementIdleTime()
        {
            Idle = Idle.Add(TimeSpan.FromSeconds(1));
        }
        #endregion
    }
}
