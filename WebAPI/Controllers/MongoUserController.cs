using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.User;
using WebAPI.Services.Contracts;

namespace WebAPI.Controllers
{
    public class MongoUserController
    {
        private readonly IMongoUser _mongoUser;

        public MongoUserController(IMongoUser mongoUser)
        {
            _mongoUser = mongoUser;
        }

        [HttpGet]
        [Route("MongoUser/GetUsers")]
        public async Task<List<User>> GetUsersAsync() => await _mongoUser.GetUsersAsync();

        [HttpPost]
        [Route("MongoUser/GetUserByName")]
        public async Task<User> GetUserByName([FromBody] UserRequest user) => await _mongoUser.GetUserByName(user.Name);
    }
}