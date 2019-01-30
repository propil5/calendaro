//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CalendaroNet.Models;
//using CalendaroNet.Models.Employees;
//using CalendaroNet.Models.Schedule;
//using CalendaroNet.Models.Services;
//using CalendaroNet.Services.Employees;
//using CalendaroNet.Services.Schedules;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace CalendaroNet.Controllers
//{
//    [Authorize]
//    public class ReserveServiceController : Controller
//    {

//        private readonly IEmployeesService _employeeService;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly ISchedulesService _scheduleManager;


//        public ReserveServiceController(IEmployeesService EmployeeService, UserManager<ApplicationUser> userManager, ISchedulesService scheduleManager)
//        {
//            _employeeService = EmployeeService;
//            _userManager = userManager;
//            _scheduleManager = scheduleManager;
//        }


//        public async Task<IActionResult> Index()
//        {
//            var currentUser = await _userManager.GetUserAsync(User);
//            var currentEmployee = await _scheduleManager.GetEmployeeIdByUserIdAsync(currentUser.Id);
//            var schedule = await _scheduleManager.GetScheduleListForEmployeeAsync(currentEmployee);

//            var model = new ScheduleListViewModel()
//            {
//                Schedule = schedule
//            };

//            return View(model);
//        }
//        [HttpGet] //list us³ug
//        public async Task<IActionResult> Add(string returnUrl = null)
//        {
//            var employees = await _employeeService.GetListOfAllEmployeesAsync();
//            var model = new WorkScheduleView()
//            {
//                CompanyEmployees = employees,
//                StartTime = DateTimeOffset.Now,
//                FinishTime = DateTimeOffset.Now,
//                Role = "Lekarz"
//            };
//            return View(model);

//        }

//        [HttpGet]//lista osób które mog¹ j¹ wykonywaæ
//        public async Task<IActionResult> Add(Guid serviceId)
//        {
//            var employees = await _employeeService.GetListOfAllEmployeesAsync();
//            var model = new WorkScheduleView()
//            {
//                CompanyEmployees = employees,
//                StartTime = DateTimeOffset.Now,
//                FinishTime = DateTimeOffset.Now,
//                Role = "Lekarz"
//            };
//            return View(model);

//        }
//        [HttpPost]
//        public async Task<IActionResult> Add(service, Guid EmployeeId)
//        {
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return RedirectToAction("Index");
//        //    }
//        // pobranie 

//            //serwic porównujacy getlistofemployeeschedule(employeeId)
//            //serwis.expectedTime serwistime 
//            //list of free hours when its possible- get list of reserved time for employee()24,01,2018 1400-1500



//            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
//            var id = _userManager.GetUserId(currentUser);
//            var currentEmployee = await _employeeService.GetEmployeeIdByUserIdAsync(id);
//            if (currentUser == null) return Challenge();
//            var schedule = new EmployeeSchedule
//            {
//                EmployeeId = currentEmployee,
//                StartTime = newSchedule.StartTime,
//                FinishTime = newSchedule.FinishTime,
//                Role = newSchedule.Role
//            };

//            var successful = await _scheduleManager
//            .AddScheduleDayAsync(schedule);

//            if (!successful)
//            {
//                return BadRequest("Could not add employee.");
//            }


//            return RedirectToAction("Index");

//        }

//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> RemoveEmployee(Guid id)
//        {
//            if (id == Guid.Empty)
//            {
//                return RedirectToAction("Index");
//            }

//            var successful = await _employeeService.DeleteEmployeeAsync(id);
//            if (!successful)
//            {
//                return BadRequest("Could not delete service.");
//            }

//            return RedirectToAction("Index");
//        }
//    }
//}