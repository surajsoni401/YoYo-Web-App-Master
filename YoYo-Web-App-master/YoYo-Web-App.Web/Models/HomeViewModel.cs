using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYoWebApp.Data.Models;

namespace YoYo_Web_App.Web.Model
{
    public class HomeViewModel
    {
        public Dictionary<String, FitnessRating> FitnessRating { get; set; }
        public List<Athlete> Athletes { get; set; }
    }
}
