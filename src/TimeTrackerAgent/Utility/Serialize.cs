using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TimeTrackerAgent.Utility
{
    public static class ObjSerialize
    {
        public static byte[] Serialize(this Object obj)
        {
            if (obj == null)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(memoryStream, obj);

                return memoryStream.ToArray();
            }
        }

        public static Object DeSerialize(this byte[] arrBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                memoryStream.Write(arrBytes, 0, arrBytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
