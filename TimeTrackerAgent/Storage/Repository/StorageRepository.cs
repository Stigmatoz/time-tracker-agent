using System;
using System.IO;
using System.Xml.Serialization;
using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Utility;

namespace TimeTrackerAgent.Storage.Repository
{
    public class StorageRepository : IStorageRepository
    {
        public Day GetCurrentDay()
        {
            return new Day();
        }

        public TimeStorage GetAll()
        {
            throw new NotImplementedException();
        }

        public TimeStorage Query(Predicate<TimeStorage> predicate)
        {
            throw new NotImplementedException();
        }

        public void Save(Day data)
        {
            try
            {
                using (FileStream fs = new FileStream(FileHelper.GetFilePath(), FileMode.OpenOrCreate))
                {
                    //byte[] arr = ObjSerialize.Serialize(data);
                    //fs.Write(arr, 0, arr.Length);
                    XmlSerializer serializer = new XmlSerializer(typeof(Day));
                    serializer.Serialize(fs, data);
                }
            }
            catch (Exception ex) { }
        }
    }
}
