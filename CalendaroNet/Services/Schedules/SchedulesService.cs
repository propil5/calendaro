using System;
using System.Threading.Tasks;
using CalendaroNet.Data;
using CalendaroNet.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CalendaroNet.Models.Employee;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CalendaroNet.Models.Schedule;

namespace CalendaroNet.Services.Schedules
{
    public class SchedulesService : ISchedulesService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser>  _userManager;

        #region EmployeeService()
        public SchedulesService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #endregion

        #region GetEmployeeById()
        public async Task<EmployeeSchedule> GetScheduleAsync(int id)
        {
            var schedule = await _context.EmployeesSchedule.FindAsync(id);

            return schedule;

        }
        #endregion

        #region AddEmployeeService()
        public async Task<bool> AddScheduleDayAsync(EmployeeSchedule schedule)
        {
            schedule.Id = Guid.NewGuid();
            _context.EmployeesSchedule.Add(schedule);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteEmployeeService()
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var deleted = false;
            var employee = await _context.EmployeesSchedule
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (employee != null)
            { 
                _context.Remove(employee);
                deleted = true;
            } else
            {
                deleted = false;
            }
        
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
        #endregion

        #region UpdateEmployeeAsync()
        public async Task<bool> UpdateEmployeeAsync(Guid id, EmployeeSchedule changedSchedule)
        {
            var schedule = await _context.EmployeesSchedule
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (schedule != null)
            { 
                schedule.EmployeeId = changedSchedule.EmployeeId;
                schedule.StartTime = changedSchedule.StartTime;
                schedule.FinishTime = changedSchedule.FinishTime;
                schedule.Role = changedSchedule.Role;
                _context.Update(schedule);
                
            } 
        
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion


        #region MarkAsPresent()

        public async Task<bool> MarkAsPresent(Guid id)
        {
             var schedule = await _context.EmployeesSchedule
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            schedule.Present = true;
            _context.Update(schedule);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }
        #endregion

        #region AddAbsenceReason()

        public async Task<bool> AddAbsenceReason(Guid id, string reasonMessage)
        {
                var schedule = await _context.EmployeesSchedule
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            schedule.Present = true;
            schedule.AbsenceReason = reasonMessage;
            _context.Update(schedule);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        #region GetScheduleListForEmployeeAsync()
        public async Task<EmployeeSchedule[]> GetScheduleListForEmployeeAsync(Guid employeeId)
        {
            var scheduleList = await _context.EmployeesSchedule
                .Where(x => x.Present!= true && x.StartTime >= DateTimeOffset.Now && x.EmployeeId == employeeId)
                .ToArrayAsync();

            return scheduleList;
        }
        #endregion

        #region GetScheduleListForEmployeeFromDateAsync()
        public async Task<EmployeeSchedule[]> GetScheduleListFromDateAsync(Guid employeeId, DateTimeOffset startSchedule)
        {
            var scheduleList = await _context.EmployeesSchedule
                .Where(x => x.Present!= true && x.StartTime >= startSchedule && x.EmployeeId == employeeId)
                .ToArrayAsync();

            return scheduleList;
        }
        #endregion


        public Task<bool> DeleteScheduleDayAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateScheduleDaysync(Guid id, EmployeeSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeSchedule[]> GetScheduleListForEmployeeAsync(int employeeId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}