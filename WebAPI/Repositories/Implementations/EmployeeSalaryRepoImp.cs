using System;
using WebAPI.Models.Context;
using WebAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.Repositories.Implementations
{
    public class EmployeeSalaryRepoImp : RepositoryImp<EmployeeSalary>, IEmployeeSalaryRepo
    {
        private readonly SQLDBContext _context;

        public EmployeeSalaryRepoImp(SQLDBContext context) : base(_context)
        {
            _context = context;
        }

        public async Task<EmployeeSalary> GetEmployeeSalaryByEmployeeIdAsync(int EmployeeId) => await Task.Run(() => { _context.EmployeeSalary.Single(x => x.EId == EmployeeId); });

    }
}
