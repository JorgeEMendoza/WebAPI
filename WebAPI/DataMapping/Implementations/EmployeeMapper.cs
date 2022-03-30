using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataMapping.Contracts;
using WebAPI.Models.Employee;

namespace WebAPI.DataMapping.Implementations
{
    public sealed class EmployeeMapper : IEmployeeMapper
    {
        public Employee_Main Map<TModel>(TModel model)
            where TModel : CreateEmployeeModel =>
            new Employee_Main
            {
                EMP_FirstName = model.FirstName,
                EMP_LastName = model.LastName
            };

        public Employee_Main MapEmployee<TModel>(TModel model)
            where TModel : Employee =>
            new Employee_Main
            {
                Emp_ID = model.ID,
                EMP_FirstName = model.FirstName,
                EMP_LastName = model.LastName
            };
    }
}
