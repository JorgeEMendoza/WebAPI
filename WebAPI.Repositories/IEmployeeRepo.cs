using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.EF.Models;

namespace WebAPI.Repositories
{
    public interface IEmployeeRepo
    {
        public Task<EmployeeDataModel> GetEmployeeById(int employeeId);
        public Task<IReadOnlyCollection<EmployeeDataModel>> GetAllEmployees();

        public Task<IReadOnlyCollection<EmployeeDataModel>> GetSomeEmployees();

        public Task Create(EmployeeDataModel employee);
    }
}
