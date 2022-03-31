using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [Route("SalaryByEmployeeId/{employeeId:int}")]
        public async Task<EmployeeSalary> GetSalaryByEmployeeId(int employeeId) => await _employeeSalaryService.GetEmployeeSalaryByEmployeeIdAsync(employeeId);
    }
}
