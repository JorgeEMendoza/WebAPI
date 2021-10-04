using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Repositories.Contracts
{
    public interface IEmployeeSalaryRepo
    {
        public Task<EmployeeSalary> GetEmployeeSalaryByEmployeeIdAsync(int EmployeeId);
    }
}
