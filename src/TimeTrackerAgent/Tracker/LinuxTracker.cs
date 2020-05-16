using System;
using System.Threading.Tasks;
using TimeTrackerAgent.Tracker.Base;

namespace TimeTrackerAgent.Tracker
{
    public class LinuxTracker : BaseTracker
    {
        public override Task StartTracking()
        {
            throw new NotImplementedException();
        }

        public override Task StopTracking()
        {
            throw new NotImplementedException();
        }
    }
}
