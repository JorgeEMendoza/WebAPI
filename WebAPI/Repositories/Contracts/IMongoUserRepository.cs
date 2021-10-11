using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.User;

namespace WebAPI.Repositories.Contracts
{
    public interface IMongoUserRepository
    {
        public Task<List<User>> GetUsersAsync();
    }
}