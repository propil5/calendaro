using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Service
{
    public class Service
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan TimeRequired { get; set; }

        public bool RoleReqired {get; set;}
    }
}