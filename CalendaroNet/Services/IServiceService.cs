using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services
{
    public interface IServiceService
    {
        Task<Service[]> GetListOfAllServicesAsync();
        Task<bool> AddServiceAsync(Service newService);
        Task<bool> DeleteServiceAsync(Guid id);
        Task<bool> EditServiceAsync(Guid id, Service changedService);
    }
}