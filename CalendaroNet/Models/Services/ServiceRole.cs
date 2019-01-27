using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Services
{
    public class ServiceRole
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description {get; set;}
       
    }
}