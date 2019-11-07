using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalAssessment.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalAssessment.Controllers
{
    // Stops user accessing Customers controller without being logged in.
    [Authorize]
    // Declaration of class 'Customers Controller'
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // returns the home index view
        public IActionResult Index()
        {
            return View();
        }

        // allows users who aren't logged in to view the privacy page
        [AllowAnonymous]
        // returns the privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // returns the error view incase of an error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
