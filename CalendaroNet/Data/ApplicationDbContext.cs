using System;
using System.Collections.Generic;
using System.Text;
using CalendaroNet.Models;
using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Schedule;
using CalendaroNet.Models.ServiceReservations;
using CalendaroNet.Models.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalendaroNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> Items { get; set; }
        public DbSet<Service> Services { get; set; }       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSchedule> EmployeesSchedules {get; set;}
        public DbSet<ServiceReservation> ServiceReservations { get; set; }


    }
}