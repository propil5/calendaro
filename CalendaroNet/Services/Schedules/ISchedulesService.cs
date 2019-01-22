// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using CalendaroNet.Models;
// using CalendaroNet.Models.Employee;
// using CalendaroNet.Models.Schedule;
// using Microsoft.AspNetCore.Identity;

// namespace CalendaroNet.Services.Schedules
// {
//     public interface ISchedulesService
//     {
//         Task<List<WorkScheduleView>> GetScheduleForMe(String id);

//         Task<List<WorkScheduleView>> GetScheduleForAll(String id);
//         Task<bool> AddScheduleDayAsync(EmployeShedule schedule);
//         Task<bool> DeleteScheduleDayAsync(Guid id);
//         Task<bool> UpdateScheduleDaysync(Guid id, EmployeShedule schedule);
//     }
// }