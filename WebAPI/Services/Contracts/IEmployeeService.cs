using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<Employee_Main> GetEmployeeAsync(int employeeID);

        public Task<IReadOnlyCollection<Employee_Main>> GetAllEmployeesAsync();

        public Task<List<Employee_Main>> GetRandomEmployeesAsync(int numberOfRandomEmployees);

        public Task Create(Employee_Main employee);
    }
}
