using System;
using System.IO;
using TimeTrackerAgent.Common;

namespace TimeTrackerAgent.Utility
{
    public class FileHelper
    {
        public static string GetFilePath()
        {
            return Path.Combine(GetDirectoryPath(), $"{DateTime.UtcNow.Date.ToString("dd.MM.yyyy")}.bin");
        }

        public static string GetDirectoryPath()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Const.ProgramName);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            
            return dir;
        }
    }
}
