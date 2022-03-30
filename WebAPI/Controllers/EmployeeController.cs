﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.DataMapping.Contracts;
using WebAPI.Models.Employee;
using WebAPI.Services.Contracts;
using static WebAPI.Controllers.RoutingHelpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
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
        public async Task<Employee_Main> GetEmployeeById(int empID) => await Task.Run(() => { return _employeeService.GetEmployeeAsync(empID); });

        [HttpGet]
        [Route("Employees")]
        public async Task<IReadOnlyCollection<Employee_Main>> GetAllEmployees() => await Task.Run(() => { return _employeeService.GetAllEmployeesAsync(); });

        [HttpGet]
        [Route("Get10RandomEmployees")]
        public async Task<List<Employee_Main>> GetSomeEmployees() => await Task.Run(() => { return _employeeService.GetRandomEmployeesAsync(10); });

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task CreateEmployee(CreateEmployeeModel employee) => await Task.Run(() =>
        {
            Employee_Main newEmployee = _mapper.Map(employee);
            return _employeeService.Create(newEmployee);
            
        });
        
    }
}
