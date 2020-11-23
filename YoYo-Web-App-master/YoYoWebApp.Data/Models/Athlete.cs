using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace YoYoWebApp.Data.Models
{
    public class Athlete
    {
        public int AthleteId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int ShuttleLevel { get; set; }
    }
}
