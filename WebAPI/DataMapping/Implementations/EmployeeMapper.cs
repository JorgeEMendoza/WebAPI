using WebAPI.Web.DataMapping.Contracts;
using WebAPI.Models;
using WebAPI.Data.EF.Models;

namespace WebAPI.Web.DataMapping.Implementations
{
    public sealed class EmployeeMapper : IEmployeeMapper
    {
        public EmployeeDataModel Map<TModel>(TModel model)
            where TModel : CreateEmployeeModel =>
            new EmployeeDataModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.DateOfBirth
            };

        public Employee MapEmployee<TModel>(TModel model)
            where TModel : EmployeeDataModel =>
            new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.BirthDate

            };
    }
}
