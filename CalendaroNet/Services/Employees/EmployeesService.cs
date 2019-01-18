using System;
using System.Threading.Tasks;
using CalendaroNet.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CalendaroNet.Models.Employee;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser>  _userManager;

        #region EmployeeService()
        public EmployeesService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #endregion

        #region AddEmployeeService()
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteEmployeeService()
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var deleted = false;
            var employee = await _context.Employees
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (employee != null)
            { 
                _context.Remove(employee);
                deleted = true;
            } else
            {
                deleted = false;
            }
        
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
        #endregion

        #region UpdateEmployeeAsync()
        public async Task<bool> UpdateEmployeeAsync(Guid id, Employee changedEmployee)
        {
            var employee = await _context.Employees
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (employee != null)
            { 
                employee.User = changedEmployee.User;
                employee.EmploymentDate = changedEmployee.EmploymentDate;
                employee.ContractEndDate = changedEmployee.ContractEndDate;
                employee.BaseMonthSalary = changedEmployee.BaseMonthSalary;
                _context.Update(employee);
                
            } 
        
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region GetListOfAllEmployeesAsync()
        public async Task<List<EmployeeViewModel>> GetListOfAllEmployeesAsync()
        {
            var employeesList = await _context.Employees
                .ToArrayAsync();
            List<EmployeeViewModel> employeesViewList = new List<EmployeeViewModel>(); 
            
            foreach(var employee in employeesList)
            {
                // String aad = employee.AdedBy.ToString();
                // String eed = employee.EditedBy.ToString();
                // String nam = employee.User.ToString();
                var addedBy = await _userManager.FindByIdAsync(employee.AdedById);
                var editedBy = await _userManager.FindByIdAsync(employee.EditedById);
                var userName = await _userManager.FindByIdAsync(employee.UserId);
                employeesViewList.Add(new EmployeeViewModel()
                {
                    Name = "addedBy.Name",
                    EmploymentDate = employee.EmploymentDate,
                    ContractEndDate = employee.ContractEndDate,
                    CreatedDate = employee.CreatedDate,
                    UpdateDate = employee.UpdateDate,
                    AdedBy = "userName.Name",
                    EditedBy = "userName.Name",
                    BaseMonthSalary = employee.BaseMonthSalary,


                });
            }
            
            return employeesViewList;
        }
        #endregion
    }
}