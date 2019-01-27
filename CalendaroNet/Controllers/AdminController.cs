using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalendaroNet.Models;
using Microsoft.AspNetCore.Authorization;

namespace CalendaroNet.Controllers
{   
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            ViewData["Message"] = "Brawo dla";

            return View();
        }



        public IActionResult Dashboard()
        {
            ViewData["Message"] = "Panel główny";

            return View();
        }

        public IActionResult Orders()
        {
            ViewData["Message"] = "Twoje zamówienia!";

            return View();
        }

        public IActionResult Customers()
        {
            ViewData["Message"] = "Twoje zamówienia!";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
