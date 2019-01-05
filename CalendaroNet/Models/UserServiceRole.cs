using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models
{
    public class UserServiceRole
    {
        public Guid Id { get; set; }
        
        public string UserId { get; set; }
        public string RoleId { get; set; }
       
    }
}