using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CalendaroNet.Models.Employees;

namespace CalendaroNet.Models.Schedule
{
    public class WorkScheduleView
    {
        public Guid Id { get; set; }

        public List<EmployeeViewModel> CompanyEmployees {get; set;}

        [Display(Name = "Pracownik")]
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        [Display(Name = "Data i godzina rozpoczêcia")]
        public DateTimeOffset StartTime { get; set; }

        [Required]
        [Display(Name = "Data i godzina zakoñczenia")]
        public DateTimeOffset FinishTime { get; set; }

        public String Role { get; set; }
        public bool? Present { get; set; }

        public String AbsenceReason {get; set;}

    }
}