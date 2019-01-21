using System;
using System.ComponentModel.DataAnnotations;

namespace CalendaroNet.Models.Employee
{
    public class EmployeeViewModel
    {

        public Guid Id{get; set;}       
        public String Name { get; set; }

        public DateTimeOffset EmploymentDate { get; set; }

        public DateTimeOffset? ContractEndDate { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }
        public String AdedBy { get; set; }
        public String EditedBy { get; set; }

        public double BaseMonthSalary { get; set; }

    }
}