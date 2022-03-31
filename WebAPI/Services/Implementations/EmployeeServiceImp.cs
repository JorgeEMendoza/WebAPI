using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.EF.Models;
using WebAPI.Repositories;
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

        public async Task<EmployeeDataModel> GetEmployeeAsync(int employeeID) => await _empRepo.GetEmployeeById(employeeID);

        public async Task<IReadOnlyCollection<EmployeeDataModel>> GetAllEmployeesAsync() => await _empRepo.GetAllEmployees();

        public async Task<IReadOnlyCollection<EmployeeDataModel>> GetRandomEmployeesAsync(int numberOfRandomEmployees)
        {
            var rand = new Random();
            IReadOnlyCollection<EmployeeDataModel> employees = await _empRepo.GetAllEmployees();

            return employees.OrderBy(x => rand.Next()).Take(numberOfRandomEmployees).ToList();
        }

        public async Task Create(EmployeeDataModel employee) => await _empRepo.Create(employee);
    }
}
