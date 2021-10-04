using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Employee;
using WebAPI.Services.Contracts;

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
        [Route("Employee/{empId:int}")]
        public async Task<Employee> GetEmployeeById(int empId) => await Task.Run(() => _employeeService.GetEmployeeAsync(empId) );

        [HttpGet]
        [Route("Employees")]
        public async Task<IReadOnlyCollection<Employee>> GetAllEmployees() => await Task.Run(() => _employeeService.GetAllEmployeesAsync() );

        [HttpGet]
        [Route("Get10RandomEmployees")]
        public async Task<List<Employee>> GetSomeEmployees() => await Task.Run(() => _employeeService.GetRandomEmployeesAsync(10) );
        
    }
}
