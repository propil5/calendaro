using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employee;
using CalendaroNet.Models.Service;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services.Services
{
    public interface IServiceService
    {
        Task<Service[]> GetListOfAllServicesAsync();
        Task<bool> AddServiceAsync(ServiceViewModel newService);
        Task<bool> DeleteServiceAsync(Guid id);
        Task<bool> UpdateServiceAsync(Guid id, Service changedService);
    }
}