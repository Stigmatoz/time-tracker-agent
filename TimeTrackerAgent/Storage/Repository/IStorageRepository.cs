using System;
using TimeTrackerAgent.Entity;

namespace TimeTrackerAgent.Storage.Repository
{
    public interface IStorageRepository
    {
        Day GetCurrentDay();
        TimeStorage GetAll();
        TimeStorage Query(Predicate<TimeStorage> predicate);
        void Save(Day data);
    }
}