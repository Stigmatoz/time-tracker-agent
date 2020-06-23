using System;
using System.IO;
using TimeTrackerAgent.Common;

namespace TimeTrackerAgent.Utility
{
    public class FileHelper
    {
        public static string GetFilePath(DateTime date)
        {
            return Path.Combine(GetDirectoryPath(), $"{date:dd.MM.yyyy}.xml");
        }

        public static string GetDirectoryPath()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Const.ProgramName, Const.StorageFolderName);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            
            return dir;
        }
    }
}
