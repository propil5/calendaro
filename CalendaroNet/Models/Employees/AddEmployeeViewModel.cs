using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalendaroNet.Models.Employees
{
    public class AddEmployeeViewModel
    {
        [Required]
        [Display(Name = "User")]
        public String UserId { get; set; }

        public string FirstName {get; set;}

        public string SecondName {get; set;}

        public string Surname {get; set;}


        public ApplicationUser[] Users {get; set;}

        public DateTimeOffset EmploymentDate { get; set; }

        public DateTimeOffset? ContractEndDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }

        public String EditedBy { get; set; }

        [Range(0, 99999.99)]
        public double BaseMonthSalary { get; set; }
    }
}