using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Services
{
    public class ServicePermission
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public Guid RoleId {get; set;}
       
    }
}