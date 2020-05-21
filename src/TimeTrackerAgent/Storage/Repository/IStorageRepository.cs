using System;
using System.Threading.Tasks;
using TimeTrackerAgent.Entity;

namespace TimeTrackerAgent.Storage.Repository
{
    public interface IStorageRepository
    {
        Task<Day> GetCurrentDayAsync();
        TimeStorage GetAll();
        TimeStorage Query(Predicate<TimeStorage> predicate);
        Task SaveAsync(Day data);
    }
}