using CalendaroNet.Models.Employees;
using CalendaroNet.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendaroNet.Models.ServiceReservations
{
    public class ServiceReservation
    {
        public Guid Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public virtual Service Service { get; set; }

        public Guid ServiceId { get; set; }

        public virtual Employee Employee { get; set; }
  
        public string EmployeeId { get; set; }

        public DateTimeOffset ReservationTime { get; set; }

        public DateTimeOffset EstimatedTime { get; set; }

        public bool? Done { get; set; }

        public String AbsenceReason { get; set; }

    }
}
