using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employee;
using CalendaroNet.Models.Schedule;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services
{
    public interface IScheduleService
    {
        Task<List<WorkScheduleView>> GetYourchedule();
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<bool> UpdateEmployeeAsync(Guid id, Employee changedEmployee);
    }
}