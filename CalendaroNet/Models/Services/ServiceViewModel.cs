using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalendaroNet.Models.Services
{
    public class ServiceViewModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int TimeRequiredInMinutes { get; set; }

        public bool RoleReqired {get; set;}

        public double PriceInPln {get; set;}
        
    }
}