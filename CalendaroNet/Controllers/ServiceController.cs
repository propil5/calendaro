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
        public async Task<IActionResult> AddService(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _todoItemService
            .AddItemAsync(newItem, currentUser);

            if (!successful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();


            var successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }
    }
}