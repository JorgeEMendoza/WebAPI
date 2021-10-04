using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Services.Contracts
{
    public interface IEmployeeSalary
    {
        public Task<EmployeeSalary> GetEmployeeSalaryByEmployeeIdAsync(int EmployeedId);
    }
}
