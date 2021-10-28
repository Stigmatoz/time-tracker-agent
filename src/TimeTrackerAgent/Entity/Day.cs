using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Day
    {
        public Day()
        {
            Date = DateTime.Now;
            IdleTime = TimeSpan.Zero;
            ActiveTime = TimeSpan.Zero;
        }

        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlIgnore]
        public TimeSpan ActiveTime { get; set; }
        [XmlIgnore]
        public TimeSpan IdleTime { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();

        [XmlElement("Date")]
        public string DateString
        {
            get { return Date.ToString("d"); }
            set { Date = DateTime.Parse(value); }
        }
        [XmlElement("ActiveTime")]
        public string ActiveTimeString
        {
            get { return ActiveTime.ToString(); }
            set { ActiveTime = TimeSpan.Parse(value); }
        }
        [XmlElement("IdleTime")]
        public string IdleTimeString
        {
            get { return ActiveTime.ToString(); }
            set { IdleTime = TimeSpan.Parse(value); }
        }

        #region Public
        public void AddApplication(string name, string path, string windowTitle, byte[] array)
        {
            Applications.Add(new Application(name, path, windowTitle, array));
        }

        public void IncrementIdleTime()
        {
            IdleTime = IdleTime.Add(TimeSpan.FromSeconds(1));
        }

        public void IncrementActiveTime()
        {
            ActiveTime = ActiveTime.Add(TimeSpan.FromSeconds(1));
        }
        #endregion
    }
}
