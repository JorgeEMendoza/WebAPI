using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.EF.Models;

namespace WebAPI.Web.Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<EmployeeDataModel> GetEmployeeAsync(int employeeID);

        public Task<IReadOnlyCollection<EmployeeDataModel>> GetAllEmployeesAsync();

        public Task<IReadOnlyCollection<EmployeeDataModel>> GetRandomEmployeesAsync(int numberOfRandomEmployees);

        public Task Create(EmployeeDataModel employee);
    }
}
