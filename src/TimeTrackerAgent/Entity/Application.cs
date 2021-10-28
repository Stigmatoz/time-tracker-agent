using System;
using System.Xml.Serialization;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Application
    {
        #region .ctor
        public Application() {}

        public Application(string name, string path, string windowTitle, byte[] array)
        {
            Name = name;
            SummaryTime = new TimeSpan();
            Icon = array;
            Path = path;
            WindowTitle = windowTitle;
        }
        #endregion

        public string Name { get; set; }
        public string Path { get; set; }
        public string WindowTitle { get; set; }
        [XmlIgnore]
        public byte[] Icon { get; set; }
        [XmlIgnore]
        public TimeSpan SummaryTime { get; set; }

        [XmlElement("SummaryTime")]
        public string SummaryTimeString
        {
            get { return SummaryTime.ToString(); }
            set { SummaryTime = TimeSpan.Parse(value); }
        }

        #region Public
        public void IncrementSummary()
        {
            SummaryTime = SummaryTime.Add(TimeSpan.FromSeconds(1));
        } 
        #endregion
    }
}
