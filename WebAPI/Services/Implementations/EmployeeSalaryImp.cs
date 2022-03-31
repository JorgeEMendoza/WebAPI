using System;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Services.Implementations
{
    public class EmployeeSalaryImp : IEmployeeSalary
    {
        private readonly IEmployeeSalaryRepo _employeeSalaryRepo;

        public EmployeeSalaryImp(IEmployeeSalaryRepo employeeSalaryRepo)
        {
            _employeeSalaryRepo = employeeSalaryRepo;
        }

        public async Task<EmployeeSalary> GetEmployeeSalaryByEmployeeIdAsync(int EmployeeId)
        {
            return await _employeeSalaryRepo.GetEmployeeSalaryByEmployeeIdAsync(EmployeeId);
        }
    }
}
