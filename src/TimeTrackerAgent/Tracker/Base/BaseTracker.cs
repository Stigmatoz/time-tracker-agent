using System.Threading.Tasks;

namespace TimeTrackerAgent.Tracker.Base
{
    public abstract class BaseTracker
    {
        public abstract Task StartTracking();

        public abstract Task StopTracking();
    }
}
