using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Storage.Repository;

namespace TimeTrackerAgent.Storage
{
    public class CurrentDay : ICurrentDay
    {
        private IStorageRepository _storageRepository;
        private Day _day;

        public CurrentDay(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
            _day = _storageRepository.GetCurrentDay();
        }

        public Day Value
        {
            get { return _day; }
            private set { _day = value; }
        }

        public void ActualizeDate()
        {
            Value = new Day();
        }
    }
}
