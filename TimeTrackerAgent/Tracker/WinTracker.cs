using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimeTrackerAgent.Entity;
using TimeTrackerAgent.Storage;
using TimeTrackerAgent.Tracker.Base;
using TimeTrackerAgent.Utility;

namespace TimeTrackerAgent.Tracker
{
    public class WinTracker : BaseTracker
    {
        #region Win API
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);
        #endregion

        #region Fields
        private Timer _activityTimer;
        private Day _day;
        #endregion

        #region .ctor
        public WinTracker(ICurrentDay currentDay)
        {
            _day = currentDay.Value;
            _activityTimer = new Timer(1000);
            _activityTimer.AutoReset = true;
            _activityTimer.Elapsed += ActivityTimerElapsed;
        }
        #endregion

        #region Public
        public override Task StartTracking()
        {
            return Task.Factory.StartNew(() =>
            {
                _activityTimer.Start();
            });
        }

        public override Task StopTracking()
        {
            return Task.Factory.StartNew(() =>
            {
                _activityTimer.Stop();
            });
        }
        #endregion

        #region Private
        private void ActivityTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var lastInputTime = GetLastInputTime();
                if (lastInputTime.HasValue && lastInputTime.Value == 0 || lastInputTime.Value < 5000)
                {
                    var processModule = GetActiveProcessModule();
                    if (processModule != null)
                    {
                        Icon ico = Icon.ExtractAssociatedIcon(processModule.FileName);
                        var array = IconHelper.IconToBytes(ico);
                        var app = _day.Applications.FirstOrDefault(x => x.Name == processModule.ModuleName);
                        if (app == null)
                            _day.AddApplication(processModule.ModuleName, processModule.FileName, array);
                        else
                        {
                            app.IncrementSummary();
                            Console.WriteLine($"{app.Name} {app.SummaryTime.ToString()}");
                        }
                    }
                }
                else if (lastInputTime > 5000)
                    return;
            }
            catch (Exception ex) { }
        }

        private ProcessModule GetActiveProcessModule()
        {
            try
            {
                const int nChars = 256;
                StringBuilder Buff = new StringBuilder(nChars);
                IntPtr handle = GetForegroundWindow();

                uint pid;
                GetWindowThreadProcessId(handle, out pid);
                Process p = Process.GetProcessById((int)pid);
                if (p != null && p.MainModule != null)
                    return p.MainModule;
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private uint? GetLastInputTime()
        {
            try
            {
                uint idleTime = 0;
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
                lastInputInfo.dwTime = 0;

                uint envTicks = (uint)Environment.TickCount;

                if (GetLastInputInfo(ref lastInputInfo))
                {
                    uint lastInputTick = lastInputInfo.dwTime;
                    idleTime = envTicks - lastInputTick;
                }

                return ((idleTime > 0) ? (idleTime / 1000) : idleTime);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
