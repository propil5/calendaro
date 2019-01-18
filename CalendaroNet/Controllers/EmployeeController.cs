using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employee;
using CalendaroNet.Models.Service;
using CalendaroNet.Services.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendaroNet.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        private readonly IEmployeesService _employeeService;
        private readonly UserManager<ApplicationUser>  _userManager;


        public EmployeeController(IEmployeesService EmployeeService, UserManager<ApplicationUser> userManager)
        {
            _employeeService = EmployeeService;
            _userManager = userManager;
        }
            
        public async Task<IActionResult> Index()
        {

            var employees = await _employeeService.GetListOfAllEmployeesAsync();

            var model = new EmployeesListViewModel()
            {
                Employees = employees
            };

            return View(model); 
        }
        [HttpGet]
        public async Task<IActionResult> AddEmployee(string returnUrl = null)
        {
            var users = await _userManager.Users
            .ToArrayAsync();
            var model = new AddEmployeeViewModel
            {
                Users = users
            };
            return View(model);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Huj");
            }
            var currentUser = await _userManager.GetUserAsync(User);
            var employeeUser = await _userManager.FindByIdAsync(newEmployee.UserId);
            if (currentUser == null) return Challenge();
            var employee = new Employee
            {
                User = employeeUser,
                EmploymentDate = newEmployee.EmploymentDate,
                ContractEndDate = newEmployee.ContractEndDate,
                CreatedDate = DateTimeOffset.Now,
                AdedBy = currentUser,
                BaseMonthSalary = newEmployee.BaseMonthSalary,
                EditedBy = currentUser

            };

            var successful = await _employeeService
            .AddEmployeeAsync(employee);

            if (!successful)
            {
                return BadRequest("Could not add employee.");
            }


            return RedirectToAction("Index");

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _employeeService.DeleteEmployeeAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete service.");
            }

            return RedirectToAction("Index");
        }
    }
}