using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Employee;
using WebAPI.Services.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("Employee/{empID}")]
        public async Task<Employee_Main> GetEmployeeById(int empID) => await Task.Run(() => { return _employeeService.GetEmployeeAsync(empID); });

        [HttpGet]
        [Route("Employees")]
        public async Task<IReadOnlyCollection<Employee_Main>> GetAllEmployees() => await Task.Run(() => { return _employeeService.GetAllEmployeesAsync(); });

        [HttpGet]
        [Route("Get10RandomEmployees")]
        public async Task<List<Employee_Main>> GetSomeEmployees() => await Task.Run(() => { return _employeeService.GetRandomEmployeesAsync(10); });
        
    }
}
