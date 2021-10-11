using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.User;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;

namespace WebAPI.Services.Implementations
{
    public class MongoUserImp : IMongoUser
    {
        private readonly IMongoUserRepository _mongoUserRepository;

        public MongoUserImp(IMongoUserRepository mongoUserRepository)
        {
            _mongoUserRepository = mongoUserRepository;
        }

        public async Task<List<User>> GetUsersAsync() => await _mongoUserRepository.GetUsersAsync();

        public async Task<User> GetUserByName(string name) => await _mongoUserRepository.GetUserByName(name);
    }
}