using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Service
{
    public class ServicePermission
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public Guid RoleId {get; set;}
       
    }
}