using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Services.Contracts
{
    public interface IEmployee
    {
        public Task<Employee> GetEmployeeAsync(int employeeId);

        public Task<IReadOnlyCollection<Employee>> GetAllEmployeesAsync();

        public Task<List<Employee>> GetRandomEmployeesAsync(int numberOfRandomEmployees);
    }
}
