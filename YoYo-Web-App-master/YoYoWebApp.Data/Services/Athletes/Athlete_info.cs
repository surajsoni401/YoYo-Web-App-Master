using System;
using System.Collections.Generic;
using System.Text;
using YoYoWebApp.Data.Models;

namespace YoYoWebApp.Data.Services.AthleteDetails
{
    public interface Athlete_info
    {
        public List<Athlete> GetAll();
        public Athlete Get(int id);
        public void updateProgress(string query);
    }
}