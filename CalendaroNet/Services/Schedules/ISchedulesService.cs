using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Schedule;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services.Schedules
{
    public interface ISchedulesService
    {
        Task<Guid> GetEmployeeIdByUserIdAsync(string currentUserId);
        Task<EmployeeSchedule[]> GetScheduleListForEmployeeAsync(Guid employeeId);

        Task<EmployeeSchedule[]> GetScheduleListFromDateAsync(Guid employeeId, DateTimeOffset startSchedule);

        Task<bool> AddAbsenceReason(Guid id, string reasonMessage);

        Task<bool> MarkAsPresent(Guid id);
        Task<bool> AddScheduleDayAsync(EmployeeSchedule schedule);
        Task<bool> DeleteScheduleDayAsync(Guid id);
        Task<bool> UpdateScheduleDaysync(Guid id, EmployeeSchedule schedule);
    }
}