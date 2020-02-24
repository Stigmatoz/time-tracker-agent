using System;

namespace TimeTrackerAgent.Entity
{
    public class Interval
    {
        public Application Application { get; private set; }
        public DateTime TimeStart { get; private set; }
        public DateTime TimeEnd { get; private set; }
    }
}
