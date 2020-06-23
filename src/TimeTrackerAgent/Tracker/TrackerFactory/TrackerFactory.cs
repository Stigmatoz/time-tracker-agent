using Microsoft.Extensions.Logging;
using TimeTrackerAgent.Storage;
using TimeTrackerAgent.Tracker.Base;

namespace TimeTrackerAgent.Tracker.TrackerFactory
{
    public class TrackerFactory : ITrackerFactory
    {
        private ICurrentDay _currentDay;
        private ILogger<TrackerFactory> _logger;

        public TrackerFactory(ICurrentDay currentDay, ILogger<TrackerFactory> logger)
        {
            _currentDay = currentDay;
            _logger = logger;
        }

        public BaseTracker GetLinuxTracker()
        {
            return new LinuxTracker();
        }

        public BaseTracker GetWinTracker()
        {
            return new WinTracker(_currentDay, _logger);
        }
    }
}
