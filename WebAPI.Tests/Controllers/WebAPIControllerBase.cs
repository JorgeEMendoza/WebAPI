using Microsoft.Extensions.Logging;
using Moq;
using WebAPI.Controllers;
using WebAPI.Services.Contracts;

namespace WebAPI.Tests.Controllers
{
    public class WebAPIControllerBase
    {
        protected EmployeeController SUT;
        protected Mock<IEmployee> _service;

        public WebAPIControllerBase()
        {
            _service = new Mock<IEmployee>();
            SUT = new EmployeeController(
                _service.Object,
                Mock.Of<ILogger<EmployeeController>>());
        }
    }
}
