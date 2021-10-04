using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models.Employee;
using WebAPI.Services.Contracts;

namespace WebAPI.Controllers
{
    public class SalaryController
    {
        private readonly IEmployeeSalary _employeeSalaryService;

        public SalaryController(IEmployeeSalary employeeSalaryService)
        {
            _employeeSalaryService = employeeSalaryService;
        }

        [HttpGet]
        [Route("SalaryByEmployeeId/{EmployeeId}")]
        public async Task<EmployeeSalary> GetSalaryByEmployeeId(int EmployeeId) => await _employeeSalaryService.GetEmployeeSalaryByEmployeeIdAsync(EmployeeId);
    }
}
