using System.Runtime.InteropServices;
using TimeTrackerAgent.Enum;

namespace TimeTrackerAgent.Entity
{
    public class LocalMachine
    {
        public LocalMachine(OSPlatform platform, string osDescription)
        {
            if (platform == OSPlatform.Windows)
                OS = OS.Windows;
            if (platform == OSPlatform.Linux)
                OS = OS.Linux;
            OSDescription = osDescription;
        }

        public OS OS { get; private set; }
        public string OSDescription { get; private set; }
    }
}
