using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Web.DataMapping.Contracts;
using WebAPI.Web.Services.Contracts;
using WebAPI.Models;
using static WebAPI.Web.Controllers.RoutingHelpers;
using WebAPI.Data.EF.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Web.Controllers
{
    [Route(VersionControllerRoute)]
    [ApiVersion(v1_0)]
    [Produces("application/json")]
    public sealed class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IEmployeeMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Employee/{empID}")]
        public async Task<Employee> GetEmployeeById(int empID)
        {
            return _mapper.MapEmployee(await Task.Run(() => _employeeService.GetEmployeeAsync(empID))); 
        }

        [HttpGet]
        [Route("Employees")]
        public async Task<IReadOnlyCollection<Employee>> GetAllEmployees()
        {
            IReadOnlyCollection<EmployeeDataModel> employees = await Task.Run(() => _employeeService.GetAllEmployeesAsync());
            List<Employee> allEmployees = new List<Employee>();

            foreach (var employee in employees)
            {
                var newEmployee = _mapper.MapEmployee(employee);
                allEmployees.Add(newEmployee);
            }

            return allEmployees;
        }

        [HttpGet]
        [Route("Get10RandomEmployees")]
        public async Task<IReadOnlyCollection<Employee>> GetSomeEmployees()
        { 
            IReadOnlyCollection<EmployeeDataModel> someEmployees = await Task.Run(() => _employeeService.GetRandomEmployeesAsync(10));
            List<Employee> top10Employees = new List<Employee>();

            foreach (var employee in someEmployees)
            {
                var newEmployee = _mapper.MapEmployee(employee);
                top10Employees.Add(newEmployee);
            }

            return top10Employees;

        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task CreateEmployee(CreateEmployeeModel employee) => await Task.Run(() =>
        {
            EmployeeDataModel newEmployee = _mapper.Map(employee);
            return _employeeService.Create(newEmployee);
            
        });
        
    }
}
