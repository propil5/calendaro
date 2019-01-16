using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Service
{
    public class ServiceReservation
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTimeOffset ReservationDate { get; set; }
    }
}