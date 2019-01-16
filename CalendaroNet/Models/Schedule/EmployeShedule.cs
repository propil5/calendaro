using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Schedule
{
    public class EmployeShedule
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid EmployeId { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset FinishTime { get; set; }

        public String Role { get; set; }
        public bool? Present { get; set; }

        public String AbsenceReason {get; set;}

    }
}