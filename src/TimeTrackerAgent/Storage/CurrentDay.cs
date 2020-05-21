using System.Threading.Tasks;
using TimeTrackerAgent.AsyncInitialization;
using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Storage.Repository;

namespace TimeTrackerAgent.Storage
{
    public class CurrentDay : ICurrentDay, IAsyncInitialization
    {
        private IStorageRepository _storageRepository;
        private Day _day;
        private object _object = new object();

        public CurrentDay(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
            Initialization = InitializeAsync();
        }

        public Task Initialization { get; private set; }

        public Day Value
        {
            get 
            {
                lock (_object)
                {
                    return _day;
                }
            }
            private set 
            {
                lock (_object)
                {
                    _day = value;
                }
            }
        }

        public void ActualizeDate()
        {
            lock (_object)
            {
                Value = new Day();
            }
        }

        #region IAsyncInitialization
        private async Task InitializeAsync()
        {
            _day = await _storageRepository.GetCurrentDayAsync();
        } 
        #endregion
    }
}
