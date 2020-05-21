using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Utility;

namespace TimeTrackerAgent.Storage.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private object _lock = new object();
        private ILogger<StorageRepository> _logger;

        public StorageRepository(ILogger<StorageRepository> logger)
        {
            _logger = logger;
        }

        #region public
        public async Task<Day> GetCurrentDayAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    Day day = new Day();

                    if (!File.Exists(FileHelper.GetFilePath(DateTime.Now)))
                        return day;
                    
                    FileReadWriteWrapper(() =>
                    {
                        using (StreamReader sr = new StreamReader(FileHelper.GetFilePath(DateTime.Now)))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Day));
                            day = (Day)serializer.Deserialize(sr);
                        }
                    });

                    return day;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    _logger.LogError(ex.InnerException?.Message);
                    return new Day();
                }
            });
        }

        public TimeStorage GetAll()
        {
            throw new NotImplementedException();
        }

        public TimeStorage Query(Predicate<TimeStorage> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(Day data)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    FileReadWriteWrapper(() =>
                    {
                        using (StreamWriter sw = new StreamWriter(File.Open(FileHelper.GetFilePath(DateTime.Now), FileMode.Create)))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Day));
                            serializer.Serialize(sw, data);
                        }
                    });
                }
                catch (Exception ex) 
                {
                    _logger.LogError(ex.Message);
                    _logger.LogError(ex.InnerException?.Message);
                }
            });
        }
        #endregion

        #region private
        private void FileReadWriteWrapper(Action action)
        {
            lock (_lock)
            {
                action();
            }
        }
        #endregion
    }
}
