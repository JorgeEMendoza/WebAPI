using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataMapping.Contracts;
using WebAPI.Models.Context;
using WebAPI.Models.Employee;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class EmployeeRepoImp : RepositoryImp<Employee_Main>, IEmployeeRepo
    {
        private readonly SQLDBContext _context;
        private readonly IEmployeeMapper _mapper;
        public EmployeeRepoImp(SQLDBContext _context, IEmployeeMapper _mapper) : base(_context)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public async Task<List<Employee_Main>> GetAllEmployees() => await Task.Run(() => 
        {
            List<Employee> employees = _context.Employee.Where(x => x.ID < 11).ToList();
            List<Employee_Main> mappedEmployees = new List<Employee_Main>();

            foreach (var employee in employees)
            {
                mappedEmployees.Add(_mapper.MapEmployee(employee));
            }

            return mappedEmployees; 
        });

        public Task<IReadOnlyCollection<Employee_Main>> GetSomeEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task Create(Employee_Main employee) => await Task.Run(() =>
        {
            _context.Employee_Main.Add(employee);
            _context.SaveChanges();
        });

    }
}
