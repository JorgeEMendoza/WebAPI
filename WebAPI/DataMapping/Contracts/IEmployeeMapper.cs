using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Employee;

namespace WebAPI.DataMapping.Contracts
{
    public interface IEmployeeMapper
    {
        Employee_Main Map<TModel>(TModel model) where TModel : CreateEmployeeModel;

        Employee_Main MapEmployee<TModel>(TModel model) where TModel : Employee;
    }
}
