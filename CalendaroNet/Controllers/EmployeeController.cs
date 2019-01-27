using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Services;
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
                CompanyEmployees = employees
            };

            return View(model); 
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddEmployee(string returnUrl = null)
        {
            var users = await _userManager.Users
            .ToArrayAsync();
            var model = new AddEmployeeViewModel
            {
                Users = users,
                EmploymentDate = DateTimeOffset.Now
            };
            return View(model);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var currentUser = await _userManager.GetUserAsync(User);
            var employedUser = await _userManager.FindByIdAsync(newEmployee.UserId);
            if (currentUser == null) return Challenge();
            var employee = new Employee
            {
                FirstName = newEmployee.FirstName,
                Surname = newEmployee.Surname,
                SecondName = newEmployee.SecondName,
                User = employedUser,
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
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _employeeService.DeleteEmployeeAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete employee.");
            }

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> EditEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            var users = await _userManager.Users.ToArrayAsync();
            //var user = await _userManager.FindByIdAsync(employee.UserId);
            var model = new AddEmployeeViewModel()
            {
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                SecondName = employee.Surname,
                Users = users,
                EmploymentDate = employee.EmploymentDate,
                ContractEndDate = employee.ContractEndDate,
                BaseMonthSalary = employee.BaseMonthSalary
            };
            return View(model);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(Guid id, AddEmployeeViewModel employee)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var employeeUser = await _userManager.FindByIdAsync(employee.UserId);
            var originEmployee = await _employeeService.GetEmployeeAsync(id);
            if (currentUser == null) return Challenge();
            var updatedEmployee = new AddEmployeeViewModel
            {
                UserId = employee.UserId,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                SecondName = employee.Surname,          
                EmploymentDate = employee.EmploymentDate,
                ContractEndDate = employee.ContractEndDate,
                BaseMonthSalary = employee.BaseMonthSalary,
                UpdateDate = DateTimeOffset.Now,
                EditedBy = currentUser.Id
            };

            var successful = await _employeeService
            .UpdateEmployeeAsync(id, updatedEmployee);

            if (!successful)
            {
                return BadRequest("Could not update employee.");
            }


            return RedirectToAction("Index");
        }
    }
}