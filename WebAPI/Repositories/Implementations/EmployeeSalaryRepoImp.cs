using System;
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

        public async Task<EmployeeSalary> GetEmployeeSalaryByEmployeeIdAsync(int EmployeeId) => await Task.Run(() => {
            var employeeSalaryData = (from es in _context.EmployeeSalary
                                     join e in _context.Employee on es.EId equals e.Id
                                     where es.EId == EmployeeId
                                     select new { Id = es.Id, 
                                         HireDate = es.HireDate, 
                                         Salary = es.Salary, 
                                         EId = es.EId,
                                         FirstName = e.FirstName,
                                         LastName = e.LastName,
                                         BirthDate = e.BirthDate,
                                         PhoneNumber = e.PhoneNumber
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
