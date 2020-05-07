using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TimeTrackerAgent.Service;
using TimeTrackerAgent.Storage.Repository;
using TimeTrackerAgent.Tracker.Base;
using TimeTrackerAgent.Tracker.TrackerFactory;
using TimeTrackerAgent.Utility;

namespace TimeTrackerAgent
{
    public class MainWorker : BackgroundService
    {
        private IStorageRepository _storageRep;
        private ILogger<MainWorker> _logger;
        private ITrackerFactory _factory;
        private IStorageService _storageService;
        private BaseTracker _tracker;

        public MainWorker(ILogger<MainWorker> logger, ITrackerFactory factory, IStorageRepository storageRep, IStorageService storageService)
        {
            _storageRep = storageRep;
            _logger = logger;
            _factory = factory;
            _storageService = storageService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            OSPlatform platform = OSHelper.GetOSPlatform();
            if (platform == OSPlatform.Windows)
                _tracker = _factory.GetWinTracker();
            if (platform == OSPlatform.Linux)
                _tracker = _factory.GetLinuxTracker();

            await _storageService.StartSaveTracking();

            await _tracker.StartTracking();
        }
    }
}
