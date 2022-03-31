using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Web.Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<Employee> GetEmployeeAsync(int employeeID);

        public Task<IReadOnlyCollection<Employee>> GetAllEmployeesAsync();

        public Task<List<Employee>> GetRandomEmployeesAsync(int numberOfRandomEmployees);

        public Task Create(Employee employee);
    }
}
