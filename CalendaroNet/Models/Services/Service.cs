using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Services
{
    public class Service
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TimeRequiredInMinutes { get; set; }

        public bool RoleReqired {get; set;}

        public double PriceInPln {get; set;}

    }
}