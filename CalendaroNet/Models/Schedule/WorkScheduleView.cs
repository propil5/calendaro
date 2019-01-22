using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CalendaroNet.Models.Employee;

namespace CalendaroNet.Models.Schedule
{
    public class WorkScheduleView
    {
        public Guid Id { get; set; }

        public List<EmployeeViewModel> Employees {get; set;}
        
        [Required]
        public Guid EmployeeId { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset FinishTime { get; set; }

        public String Role { get; set; }
        public bool? Present { get; set; }

        public String AbsenceReason {get; set;}

    }
}