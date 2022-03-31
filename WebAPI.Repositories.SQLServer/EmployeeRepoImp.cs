using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Web.DataMapping.Contracts;
using WebAPI.Models.Context;
using WebAPI.Models;
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
        public async Task<List<Employee>> GetAllEmployees() => await Task.Run(() => 
        {
            List<Employee> employees = _context.Employee.Where(x => x.ID < 11).ToList();
            
            return employees; 
        });

        public Task<IReadOnlyCollection<Employee>> GetSomeEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task Create(Employee employee) => await Task.Run(() =>
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        });

        Task<Employee> IRepository<Employee>.GetById(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
