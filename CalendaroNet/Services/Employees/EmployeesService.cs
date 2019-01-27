using System;
using System.Threading.Tasks;
using CalendaroNet.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CalendaroNet.Models.Employees;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        #region EmployeeService()
        public EmployeesService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #endregion


        #region GetEmployeeById()
        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return employee;

        }
        #endregion

        #region GetEmployeeById()
        public async Task<Guid> GetEmployeeIdByUserIdAsync(string id)
        {
            var employee = await _context.Employees
                .Where(x => x.UserId == id)
                .SingleOrDefaultAsync();

            return employee.Id;

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
            }
            else
            {
                deleted = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
        #endregion

        #region UpdateEmployeeAsync()
        public async Task<bool> UpdateEmployeeAsync(Guid id, AddEmployeeViewModel changedEmployee)
        {
            var employee = await _context.Employees
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            var user = await _userManager.FindByIdAsync(changedEmployee.UserId);
            var editedBy = await _userManager.FindByIdAsync(changedEmployee.EditedBy);

            if (employee != null)
            {
                employee.User = user;
                employee.EmploymentDate = changedEmployee.EmploymentDate;
                employee.ContractEndDate = changedEmployee.ContractEndDate;
                employee.BaseMonthSalary = changedEmployee.BaseMonthSalary;
                employee.UpdateDate = changedEmployee.UpdateDate;
                employee.EditedBy = editedBy;
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

            foreach (var employee in employeesList)
            {
                // String aad = employee.AdedBy.ToString();
                // String eed = employee.EditedBy.ToString();
                // String nam = employee.User.ToString();
                //var editedById = await _userManager.Users.Include(x => x.Name).FirstOrDefault(x => x.Id == (employee.Id));
                var addedBy = await _userManager.FindByIdAsync(employee.AdedById);
                var editedBy = await _userManager.FindByIdAsync(employee.EditedById);
                //var userName = await _userManager.FindByIdAsync(employee.UserId);
                employeesViewList.Add(new EmployeeViewModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    Surname = employee.Surname,
                    SecondName = employee.SecondName,
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