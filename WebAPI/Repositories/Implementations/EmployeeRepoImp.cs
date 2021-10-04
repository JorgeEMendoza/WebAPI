using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Context;
using WebAPI.Models.Employee;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class EmployeeRepoImp : RepositoryImp<Employee>, IEmployeeRepo
    {
        private readonly SQLDBContext _context;

        public EmployeeRepoImp(SQLDBContext _context) : base(_context)
        {
            this._context = _context;
        }

        public async Task<List<Employee>> GetAllEmployees() => await Task.Run(() => { return _context.Set<Employee>().ToList(); } );

        public Task<IReadOnlyCollection<Employee>> GetSomeEmployees()
        {
            throw new NotImplementedException();
        }

    }
}
