using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Services;
using CalendaroNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendaroNet.Controllers
{
    [Authorize]
    public class RandomController : Controller
    {

        //private readonly IEmployeeService _employeeService;


        public RandomController()
        {

        }
            
        public IActionResult Index()
        {
            return View(); 
        }
    }
}