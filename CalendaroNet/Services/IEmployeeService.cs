using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employee;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetListOfAllEmployeesAsync();
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<bool> UpdateEmployeeAsync(Guid id, Employee changedEmployee);
    }
}