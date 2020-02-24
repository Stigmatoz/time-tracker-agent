using System.Threading.Tasks;
using TimeTrackerAgent.Entity;

namespace TimeTrackerAgent.Service
{
    public interface IStorageService
    {
        Task StartSaveTracking();
        Task StopSaveTracking();
    }
}