using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Repositories.Contracts
{
    public interface IEmployeeRepo : IRepository<Employee>
    {
        public Task<List<Employee>> GetAllEmployees();

        public Task<IReadOnlyCollection<Employee>> GetSomeEmployees();
    }
}
