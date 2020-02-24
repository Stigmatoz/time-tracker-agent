using System.Collections.Concurrent;
using System.Collections.Generic;
using TimeTrackerAgent.Entity;

namespace TimeTrackerAgent.Storage
{
    public class TimeStorage
    {
        public IList<Day> Days { get; private set; } = new List<Day>();

        #region Public
        public void AddDay()
        {
            Days.Add(new Day());
        }
        #endregion
    }
}
