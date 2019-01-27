using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Employees
{
    public class EmployeeViewModel
    {

        public Guid Id{get; set;}       
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string Surname { get; set; }

        public DateTimeOffset EmploymentDate { get; set; }

        public DateTimeOffset? ContractEndDate { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }
        public string AdedBy { get; set; }
        public string EditedBy { get; set; }

        public double BaseMonthSalary { get; set; }

    }
}