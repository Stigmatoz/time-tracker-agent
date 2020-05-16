using TimeTrackerAgent.Storage;
using TimeTrackerAgent.Tracker.Base;

namespace TimeTrackerAgent.Tracker.TrackerFactory
{
    public interface ITrackerFactory
    {
        BaseTracker GetWinTracker();
        BaseTracker GetLinuxTracker();
    }
}