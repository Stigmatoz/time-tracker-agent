using System;
using System.Collections.Generic;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Day
    {
        public Day()
        {
            Date = DateTime.UtcNow;
        }

        public DateTime Date { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();

        #region Public
        public void AddApplication(string name, string path, string windowTitle, byte[] array)
        {
            Applications.Add(new Application(name, path, windowTitle, array));
        }
        #endregion
    }
}
