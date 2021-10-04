using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Context;
using WebAPI.Models.Employee;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class EmployeeRepoImp : RepositoryImp<Employee_Main>, IEmployeeRepo
    {
        private readonly SQLDBContext _context;
        public EmployeeRepoImp(SQLDBContext _context) : base(_context)
        {
            this._context = _context;
        }
        public async Task<List<Employee_Main>> GetAllEmployees() => await Task.Run(() => { return _context.Set<Employee_Main>().ToList(); } );

        public Task<IReadOnlyCollection<Employee_Main>> GetSomeEmployees()
        {
            throw new NotImplementedException();
        }

    }
}
