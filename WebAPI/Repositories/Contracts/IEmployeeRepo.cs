using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Repositories.Contracts
{
    public interface IEmployeeRepo : IRepository<Employee_Main>
    {
        public Task<List<Employee_Main>> GetAllEmployees();

        public Task<IReadOnlyCollection<Employee_Main>> GetSomeEmployees();

        public Task Create(Employee_Main employee);
    }
}
