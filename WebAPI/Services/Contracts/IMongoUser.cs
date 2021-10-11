using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.User;

namespace WebAPI.Services.Contracts
{
    public interface IMongoUser
    {
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByName(string name);
    }
}