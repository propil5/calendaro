using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CalendaroNet.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {

        private readonly IServiceService _serviceService;


        public ServiceController(IServiceService ServiceService)
        {
            _serviceService = ServiceService;
        }
            
        public async Task<IActionResult> Index()
        {

            var services = await _serviceService.GetListOfAllServicesAsync();

            var model = new ServiceViewModel()
            {
                Services = services
            };

            return View(model); 
        }

        [Authorize]
        public async Task<IActionResult> AddService(Service newService)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            var successful = await _serviceService
            .AddServiceAsync(newService);

            if (!successful)
            {
                return BadRequest("Could not add service.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServiceAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _serviceService.DeleteServiceAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete service.");
            }

            return RedirectToAction("Index");
        }
    }
}