using System;
using System.Runtime.InteropServices;

namespace TimeTrackerAgent.Utility
{
    public static class OSHelper
    {
        public static string GetOSDescription()
        {
            return RuntimeInformation.OSDescription;
        }

        public static OSPlatform GetOSPlatform() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? OSPlatform.Windows : (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? OSPlatform.Linux : throw new NotSupportedException());
    }
}
