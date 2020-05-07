using System;
using System.Collections.Generic;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Day
    {
        public List<Application> Applications { get; set; } = new List<Application>();

        #region Public
        public void AddApplication(string name, string path, byte[] array)
        {
            Applications.Add(new Application(name, path, array));
        }
        #endregion
    }
}
