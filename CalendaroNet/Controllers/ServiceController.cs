using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Services;
using CalendaroNet.Services;
using CalendaroNet.Services.Services;
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

            var model = new ServiceListViewModel()
            {
                Services = services
            };

            return View(model); 
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddService(string returnUrl = null)
        {
            var model = new ServiceViewModel();
            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> AddService(ServiceViewModel newService)
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
        public async Task<IActionResult> DeleteService(Guid id)
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

        // public async Task<IActionResult> EditEmployee(Guid id)
        // {
        //     var employee = await _employeeService.GetEmployeeAsync(id);
        //     var users = await _userManager.Users.ToArrayAsync();
        //     var user = await _userManager.FindByIdAsync(employee.UserId);
        //     var model = new AddEmployeeViewModel()
        //     {
        //         Name = "user.Name",
        //         Users = users,
        //         EmploymentDate = employee.EmploymentDate,
        //         ContractEndDate = employee.ContractEndDate,
        //         BaseMonthSalary = employee.BaseMonthSalary
        //     };
        //     return View(model);
            
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> EditEmployee(Guid id, AddEmployeeViewModel employee)
        // {
        //     var currentUser = await _userManager.GetUserAsync(User);
        //     var employeeUser = await _userManager.FindByIdAsync(employee.UserId);
        //     var originEmployee = await _employeeService.GetEmployeeAsync(id);
        //     if (currentUser == null) return Challenge();
        //     var updatedEmployee = new AddEmployeeViewModel
        //     {
        //         UserId = employee.UserId,
                
        //         EmploymentDate = employee.EmploymentDate,
        //         ContractEndDate = employee.ContractEndDate,
        //         BaseMonthSalary = employee.BaseMonthSalary,
        //         UpdateDate = DateTimeOffset.Now,
        //         EditedBy = currentUser.Id
        //     };

        //     var successful = await _employeeService
        //     .UpdateEmployeeAsync(id, updatedEmployee);

        //     if (!successful)
        //     {
        //         return BadRequest("Could not update employee.");
        //     }


        //     return RedirectToAction("Index");
        // }
    }
}