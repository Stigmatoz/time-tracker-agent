using System;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Application
    {
        #region .ctor
        public Application(string name, string path, byte[] array)
        {
            Name = name;
            SummaryTime = new TimeSpan();
            Icon = array;
            Path = path;
        }
        #endregion

        public string Name { get; private set; }
        public string Path { get; private set; }
        public byte[] Icon { get; private set; }
        public TimeSpan SummaryTime { get; private set; }

        #region Public
        public void IncrementSummary()
        {
            SummaryTime = SummaryTime.Add(TimeSpan.FromSeconds(1));
        } 
        #endregion
    }
}
