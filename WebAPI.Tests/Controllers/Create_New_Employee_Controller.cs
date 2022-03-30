using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace WebAPI.Tests.Controllers
{
    public class Create_New_Employee_Controller : WebAPIControllerBase
    {
        [Fact]
        public Create_New_Employee_Controller()
        {
            _service.Setup(x => x.Create(iterator.IsAny<CreateEmployeeModel>())).ReturnAsync(new ContentResponse<EmployeeResponseModel, EmployeeValidationErrors>
            {
                Content = new EmployeeResponseModel
                {

                }
            });

            var result = await SUT.CreateEmployee(MockedCreateEmployeeModel());

            //Assert
            Assert.IsType<ObjectResult>(result);
            var response = (ObjectResult)result;
            Assert.IsType<ContentResponse<EmployeeResponseModel, EmployeeValidationErrors>>(response.Value);
            var content = (ContentResponse<EmployeeResponseModel, EmployeeValidationErrors>)response.Value;
            Assert.Equal("1", content.Content.Employee.Metadata.Id);
            Assert.Null(content.Message);

        }

        /*[Fact]
        public async Task Create_New_Course_Returns_Successful_Response()
        {
            //Arrange
            _service.Setup(x => x.CreateAsync(It.IsAny<CourseRequestModel>())).ReturnsAsync(new ContentResponse<CourseResponseModel, CourseValidationErrors>
            {
                Content = new CourseResponseModel
                {
                    Course = new Course<IReadOnlyCollection<CourseFrequency>>
                    {
                        Metadata = new EntityMetadata
                        {
                            Id = "1"
                        }
                    }
                }
            });

            //Act
            var result = await SUT.CreateAsync(MockedCourseRequestModel());

            Assert.IsType<ObjectResult>(result);
            var response = (ObjectResult)result;
            Assert.True(response.StatusCode == 201);
            Assert.IsType<ContentResponse<CourseResponseModel, CourseValidationErrors>>(response.Value);
            var content = (ContentResponse<CourseResponseModel, CourseValidationErrors>)response.Value;
            Assert.Equal("1", content.Content.Course.Metadata.Id);
            Assert.Null(content.Message);
        }

        [Fact]
        public async Task Create_New_Course_Returns_Failure_Response()
        {
            //Arrange
            _service.Setup(x => x.CreateAsync(It.IsAny<CourseRequestModel>())).ThrowsAsync(new Exception());

            //Act
            var result = await SUT.CreateAsync(MockedCourseRequestModel());

            //Assert
            Assert.IsType<StatusCodeResult>(result);
            var response = result as StatusCodeResult;
            Assert.True(response.StatusCode == 500);
        }

        [Fact]
        public async Task Create_New_Course_Returns_Failure_Response_With_Validation_Errors()
        {

            //Arrange
            var contentResponse = new ContentResponse<CourseResponseModel, CourseValidationErrors>();
            contentResponse.Message = "Failed to Create";
            contentResponse.ValidationErrors.Add(CourseValidationErrors.CourseNameMissing);
            _service.Setup(x => x.CreateAsync(It.IsAny<CourseRequestModel>())).ReturnsAsync(contentResponse);

            //Act
            var result = await SUT.CreateAsync(MockedCourseRequestModel());

            //Assert
            Assert.IsType<ObjectResult>(result);
            var response = (ObjectResult)result;
            Assert.True(response.StatusCode == 400);
            Assert.IsType<ContentResponse<CourseResponseModel, CourseValidationErrors>>(response.Value);
            var content = (ContentResponse<CourseResponseModel, CourseValidationErrors>)response.Value;
            Assert.NotEmpty(content.Message);
            Assert.True(content.ValidationErrors.Count() > 0);
        }*/
    }
}
