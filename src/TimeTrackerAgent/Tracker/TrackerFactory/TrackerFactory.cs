using TimeTrackerAgent.Storage;
using TimeTrackerAgent.Tracker.Base;

namespace TimeTrackerAgent.Tracker.TrackerFactory
{
    public class TrackerFactory : ITrackerFactory
    {
        private ICurrentDay _currentDay;

        public TrackerFactory(ICurrentDay currentDay)
        {
            _currentDay = currentDay;
        }

        public BaseTracker GetLinuxTracker()
        {
            return new LinuxTracker();
        }

        public BaseTracker GetWinTracker()
        {
            return new WinTracker(_currentDay);
        }
    }
}
