using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Models;
using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Services;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services.Services
{
    public interface IServiceService
    {
        Task<Service[]> GetListOfAllServicesAsync();
        Task<Service[]> GetListOfAllServicesClientAsync();
        Task<bool> AddServiceAsync(ServiceViewModel newService);
        Task<bool> DeleteServiceAsync(Guid id);
        Task<bool> UpdateServiceAsync(Guid id, Service changedService);
    }
}