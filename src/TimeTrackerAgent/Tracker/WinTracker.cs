using Microsoft.Extensions.Logging;
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
        private ILogger<TrackerFactory.TrackerFactory> _logger;
        private ICurrentDay _day;
        #endregion

        #region .ctor
        public WinTracker(ICurrentDay currentDay, ILogger<TrackerFactory.TrackerFactory> logger)
        {
            _logger = logger;
            _day = currentDay;
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
                if (lastInputTime.HasValue && lastInputTime.Value == 0 || lastInputTime.Value < 5)
                {
                    var process = GetActiveProcessModule();
                    if (process != null)
                    {
                        CheckCurrentDay();

                        Icon ico = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
                        var array = IconHelper.IconToBytes(ico.ToBitmap());
                        var app = _day.Value.Applications.FirstOrDefault(x => x.Name == process.MainModule.ModuleName);
                        if (app == null)
                            _day.Value.AddApplication(process.MainModule.ModuleName, process.MainModule.FileName, process.MainWindowTitle, array);
                        else
                        {
                            app.IncrementSummary();
                        }

                        _day.Value.IncrementActiveTime();
                    }
                }
                else if (lastInputTime > 5)
                {
                    CheckCurrentDay();
                    _day.Value.IncrementIdleTime();
                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} {ex.InnerException?.Message}");
            }
        }

        #region Win API
        private Process GetActiveProcessModule()
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
                    return p;
                else return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} {ex.InnerException?.Message}");
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
                _logger.LogError($"{ex.Message} {ex.InnerException?.Message}");
                return null;
            }
        }
        #endregion

        private void CheckCurrentDay()
        {
            if (DateTime.Now.Day != _day.Value.Date.Day)
                _day.ActualizeDate();

        }
        #endregion
    }
}
