using System;
using System.Threading.Tasks;
using System.Timers;
using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Storage;
using TimeTrackerAgent.Storage.Repository;

namespace TimeTrackerAgent.Service
{
    public class StorageService : IStorageService
    {
        private IStorageRepository _storageRepository;
        private ICurrentDay _currentDay;
        private Timer _timer;

        public StorageService(IStorageRepository storageRepository, ICurrentDay currentDay)
        {
            _storageRepository = storageRepository;
            _currentDay = currentDay;

            _timer = new Timer(10000);
            _timer.AutoReset = true;
            _timer.Elapsed += ActivityTimerElapsed;
        }

        public Task StartSaveTracking()
        {
            return Task.Factory.StartNew(() =>
            {
                _timer.Start();
            });
        }

        public Task StopSaveTracking()
        {
            return Task.Factory.StartNew(() =>
            {
                _timer.Stop();
            });
        }

        private void ActivityTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _storageRepository.Save(_currentDay.Value);
        }
    }
}
