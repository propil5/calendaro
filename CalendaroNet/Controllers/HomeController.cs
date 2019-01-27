using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalendaroNet.Models;
using CalendaroNet.Models.Services;
using CalendaroNet.Services.Services;

namespace CalendaroNet.Controllers
{
    public class HomeController : Controller
    {   

        private readonly IServiceService _serviceService;

        public HomeController(IServiceService ServiceService)
        {
            _serviceService = ServiceService;
        }
            
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "O nas.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Kontakt do nas.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Services()
        {

            ViewData["Message"] = "Nasze usługi!.";

            var services = await _serviceService.GetListOfAllServicesClientAsync();

            var model = new ServiceListViewModel()
            {
                Services = services
            };

            return View(model); 
        }


    }
}
