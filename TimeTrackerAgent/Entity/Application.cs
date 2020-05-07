﻿using System;

namespace TimeTrackerAgent.Entity
{
    [Serializable]
    public class Application
    {
        #region .ctor
        public Application() {}

        public Application(string name, string path, byte[] array)
        {
            Name = name;
            SummaryTime = new TimeSpan();
            Icon = array;
            Path = path;
        }
        #endregion

        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Icon { get; set; }
        public TimeSpan SummaryTime { get; set; }

        #region Public
        public void IncrementSummary()
        {
            SummaryTime = SummaryTime.Add(TimeSpan.FromSeconds(1));
        } 
        #endregion
    }
}
