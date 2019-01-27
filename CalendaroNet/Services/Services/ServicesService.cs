using System;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Data;
using CalendaroNet.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace CalendaroNet.Services.Services
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
        public async Task<bool> AddServiceAsync(ServiceViewModel newService)
        {

            var service = new Service{
                Id = Guid.NewGuid(),
                Name = newService.Name,
                TimeRequiredInMinutes = newService.TimeRequiredInMinutes,
                Description = newService.Description,
                RoleReqired = newService.RoleReqired,
                PriceInPln = newService.PriceInPln
            };
        
            _context.Services.Add(service);

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
        public async Task<bool> UpdateServiceAsync(Guid id, Service changedService)
        {
            var service = await _context.Services
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (service != null)
            { 
                service.Name = changedService.Name;
                service.RoleReqired = changedService.RoleReqired;
                service.TimeRequiredInMinutes = changedService.TimeRequiredInMinutes;
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

        #region GetListOfAllClientServices()
        public async Task<Service[]> GetListOfAllServicesClientAsync()
        {
            var services = await _context.Services
                .ToArrayAsync();
            return services;
        }
        #endregion
    }
}