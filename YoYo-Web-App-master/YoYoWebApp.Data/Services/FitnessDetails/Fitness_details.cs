using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using YoYoWebApp.Data.Models;

namespace YoYoWebApp.Data.Services.FitnessDetails
{
    public class Fitness_details : Fitness_data
    {
        public Dictionary<String, FitnessRating> GetAll()
        {
            var jsonData = File.ReadAllText("/Users/mehulvani/Downloads/YoYo-Web-App-master/fitnessrating_beeptest.json");
            var fitnessRating = JsonSerializer.Deserialize<FitnessRating[]>(jsonData);
            Dictionary<String, FitnessRating> fitnessRatingDictionary = new Dictionary<String, FitnessRating>();
            foreach (FitnessRating _fitnessRating in fitnessRating)
                fitnessRatingDictionary.Add(_fitnessRating.StartTime, _fitnessRating);
            return fitnessRatingDictionary;
        }
    }
}
