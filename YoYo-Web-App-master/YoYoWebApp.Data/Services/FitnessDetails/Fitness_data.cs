using System;
using System.Collections.Generic;
using System.Text;
using YoYoWebApp.Data.Models;

namespace YoYoWebApp.Data.Services.FitnessDetails
{
    interface Fitness_data
    {
        public Dictionary<String, FitnessRating> GetAll();
    }
}
