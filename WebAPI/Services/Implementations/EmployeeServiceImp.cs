using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Contracts;
using WebAPI.Web.Services.Contracts;

namespace WebAPI.Web.Services.Implementations
{
    public class EmployeeServiceImp : IEmployeeService
    {
        private readonly IEmployeeRepo _empRepo;

        public EmployeeServiceImp(IEmployeeRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<Employee> GetEmployeeAsync(int employeeID) => await _empRepo.GetById(employeeID);

        public async Task<IReadOnlyCollection<Employee>> GetAllEmployeesAsync() => await _empRepo.GetAllEmployees();

        public async Task<List<Employee>> GetRandomEmployeesAsync(int numberOfRandomEmployees)
        {
            var rand = new Random();
            List<Employee> employees = await _empRepo.GetAllEmployees();

            return employees.OrderBy(x => rand.Next()).Take(numberOfRandomEmployees).ToList();
        }

        public async Task Create(Employee employee) => await _empRepo.Create(employee);
    }
}
