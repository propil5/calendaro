using System;
using System.Collections.Generic;
using System.Text;
using CalendaroNet.Models;
using CalendaroNet.Models.Employee;
using CalendaroNet.Models.Service;
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

    }
}