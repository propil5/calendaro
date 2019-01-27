using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models.Employees;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services.Employees
{
    public interface IEmployeesService
    {
        Task<List<EmployeeViewModel>> GetListOfAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(Guid Id);
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<Guid> GetEmployeeIdByUserIdAsync(string id);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<bool> UpdateEmployeeAsync(Guid id, AddEmployeeViewModel changedEmployee);
    }
}