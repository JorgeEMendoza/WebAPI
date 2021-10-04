using WebAPI.Models.Context;
using WebAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.Employee;
using System.Linq;

namespace WebAPI.Repositories.Implementations
{
    public class EmployeeSalaryRepoImp : RepositoryImp<EmployeeSalary>, IEmployeeSalaryRepo
    {
        private readonly SQLDBContext _context;

        public EmployeeSalaryRepoImp(SQLDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EmployeeSalary> GetEmployeeSalaryByEmployeeIdAsync(int employeeId) => await Task.Run(() => {
            var employeeSalaryData = (from es in _context.EmployeeSalary
                                     join e in _context.Employee on es.EId equals e.Id
                                     where es.EId == employeeId
                                     select new { es.Id, 
                                         es.HireDate, 
                                         es.Salary, 
                                         es.EId,
                                         e.FirstName,
                                         e.LastName,
                                         e.BirthDate,
                                         e.PhoneNumber
                                     }).FirstOrDefault();

            EmployeeSalary data = new EmployeeSalary()
            {
                EId = employeeSalaryData.EId,
                Id = employeeSalaryData.Id,
                HireDate = employeeSalaryData.HireDate,
                Salary = employeeSalaryData.Salary,
                Employee = new Employee()
                {
                    Id = employeeSalaryData.EId,
                    FirstName = employeeSalaryData.FirstName,
                    LastName = employeeSalaryData.LastName,
                    BirthDate = employeeSalaryData.BirthDate,
                    PhoneNumber = employeeSalaryData.PhoneNumber
                }
            };

            return data;
        });

    }
}
