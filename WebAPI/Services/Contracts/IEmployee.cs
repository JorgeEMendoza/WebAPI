using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Services.Contracts
{
    public interface IEmployee
    {
        public Task<Employee_Main> GetEmployeeAsync(int employeeID);

        public Task<IReadOnlyCollection<Employee_Main>> GetAllEmployeesAsync();

        public Task<List<Employee_Main>> GetRandomEmployeesAsync(int numberOfRandomEmployees);
    }
}
