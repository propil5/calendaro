using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models
{
    public class ServiceReservation
    {
        public Guid Id { get; set; }
                
        public String ServiceId { get; set; }

        public String UserId {get; set;}
    }
}