using System;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Data;
using CalendaroNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CalendaroNet.Services
{
    public class ServiceService : IServiceService
    {
        
        private readonly ApplicationDbContext _context;
        
        #region ServiceService()
        public ServiceService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddServiceAsync()
        public async Task<bool> AddServiceAsync(Service newService)
        {
            newService.Id = Guid.NewGuid();

            _context.Services.Add(newService);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteServiceAsync()
        public async Task<bool> DeleteServiceAsync(Guid id)
        {
            var deleted = false;
            var service = await _context.Services
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (service != null)
            { 
                _context.Remove(service);
                deleted = true;
            } else
            {
                deleted = false;
            }
        
        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1 && deleted == true;
            
        }
        #endregion

        #region EditService()
        public async Task<bool> EditServiceAsync(Guid id, Service changedService)
        {
            var service = await _context.Services
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (service != null)
            { 
                service.Name = changedService.Name;
                service.RoleReqired = changedService.RoleReqired;
                service.TimeRequired = changedService.TimeRequired;
                service.Description = changedService.Description;
                _context.Update(service);
                
            } 
        
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region GetListOfAllServices()
        public async Task<Service[]> GetListOfAllServicesAsync()
        {
            var services = await _context.Services
                .ToArrayAsync();
            return services;
        }
        #endregion
    }
}