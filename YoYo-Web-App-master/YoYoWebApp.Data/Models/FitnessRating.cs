using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace YoYoWebApp.Data.Models
{
    public class FitnessRating 
    {
        public string AccumulatedShuttleDistance { get; set; }
        public string SpeedLevel { get; set; }
        public string ShuttleNo { get; set; }
        public string Speed { get; set; }
        public string LevelTime { get; set; }
        public string CommulativeTime { get; set; }
        public string StartTime { get; set; }
        public string ApproxVo2Max { get; set; }
    }
}
