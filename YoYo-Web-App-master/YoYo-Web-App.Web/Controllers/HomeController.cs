using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoYo_Web_App.Web.Models;
using YoYo_Web_App.Web.Model;
using YoYoWebApp.Data.Services;
using YoYoWebApp.Data.Services.AthleteDetails;
using YoYoWebApp.Data.Services.FitnessDetails;
using YoYoWebApp.Data.Models;

namespace YoYo_Web_App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeViewModel _homeViewModel;
        public Fitness_details objFitnessRating;
        public Athlete_details objAthletes;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            objFitnessRating = new Fitness_details();
            objAthletes = new Athlete_details();
            _homeViewModel = new HomeViewModel();
            _homeViewModel.FitnessRating= objFitnessRating.GetAll();
            _homeViewModel.Athletes = objAthletes.GetAll();
        }

        public IActionResult Index()
        {
            return View(_homeViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id, int level, int shuttleLevel)
        {
          
            Athlete athlete = objAthletes.Get(id);
            athlete.Level = level;
            athlete.ShuttleLevel = shuttleLevel;
            return View(athlete);
        }

        public IActionResult Detail(string query)
        {
            objAthletes.updateProgress(query);
            var athletes=objAthletes.GetAll();
            return View(athletes);
        }

        public IActionResult Details()
        {
            var athletes = objAthletes.GetAll();
            return View(athletes);
        }

        public IActionResult Save(int id, int level,int shuttleLevel)
        {
            Athlete athlete = objAthletes.Get(id);

            var athletes = objAthletes.GetAll();

            return View(athletes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
