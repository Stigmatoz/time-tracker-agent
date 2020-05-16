using TimeTrackerAgent.Entity;

namespace TimeTrackerAgent.Storage
{
    public interface ICurrentDay
    {
        Day Value { get; }
        void ActualizeDate();
    }
}