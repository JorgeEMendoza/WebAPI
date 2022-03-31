using WebAPI.Data.EF.Models;
using WebAPI.Models;

namespace WebAPI.Web.DataMapping.Contracts
{
    public interface IEmployeeMapper
    {
        EmployeeDataModel Map<TModel>(TModel model) where TModel : CreateEmployeeModel;

        Employee MapEmployee<TModel>(TModel model) where TModel : EmployeeDataModel;
    }
}
