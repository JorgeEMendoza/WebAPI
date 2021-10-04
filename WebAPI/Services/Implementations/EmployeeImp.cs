using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Employee;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;

namespace WebAPI.Services.Implementations
{
    public class EmployeeImp : IEmployee
    {
        private readonly IEmployeeRepo _empRepo;

        public EmployeeImp(IEmployeeRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<Employee_Main> GetEmployeeAsync(int employeeID) => await _empRepo.GetById(employeeID);

        public async Task<IReadOnlyCollection<Employee_Main>> GetAllEmployeesAsync() => await _empRepo.GetAllEmployees();

        public async Task<List<Employee_Main>> GetRandomEmployeesAsync(int numberOfRandomEmployees)
        {
            var rand = new Random();
            List<Employee_Main> employees = await _empRepo.GetAllEmployees();

            return employees.OrderBy(x => rand.Next()).Take(numberOfRandomEmployees).ToList();
        }
    }
}
