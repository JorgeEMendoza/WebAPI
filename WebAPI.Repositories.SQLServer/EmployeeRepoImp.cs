using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Context;
using WebAPI.Models;
using WebAPI.Data.EF.Models;

namespace WebAPI.Repositories.Implementations
{
    public class EmployeeRepoImp : RepositoryImp<Employee>, IEmployeeRepo
    {
        private readonly SQLDBContext _context;
        public EmployeeRepoImp(SQLDBContext _context) : base(_context)
        {
            this._context = _context;
        }

        public async Task<EmployeeDataModel> GetEmployeeById(int employeeId) => await Task.Run(() => _context.employees.Where(x => x.Id == employeeId).FirstOrDefault());
        public async Task<IReadOnlyCollection<EmployeeDataModel>> GetAllEmployees() => await Task.Run(() => 
        {
            List<EmployeeDataModel> employees = _context.employees.Where(x => x.Id < 11).ToList();
            
            return employees; 
        });

        public Task<IReadOnlyCollection<EmployeeDataModel>> GetSomeEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task Create(EmployeeDataModel employee) => await Task.Run(() =>
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
        });

    }
}
