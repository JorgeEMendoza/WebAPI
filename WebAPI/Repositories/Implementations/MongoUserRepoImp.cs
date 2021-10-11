using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPI.Models.User;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class MongoUserRepoImp : IMongoUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoUserRepoImp()
        {
            IMongoClient mongoClient = new MongoClient("mongodb://mongoDBAdmin:mongoDBAdmin@192.168.2.220:27017/?authSource=admin");
            _mongoDatabase = mongoClient.GetDatabase("TestDB");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = new List<User>();
            
            List<UserInDb> usersInDb = new List<UserInDb>();

            foreach (UserInDb user in usersInDb)
            {
                users.Add(new User
                {
                    Id = user._id,
                    FirstName = user.name,
                    LastName = user.last_name,
                    PhoneNumbers = user.phone_numbers
                    
                });
            }

            return users;
        }

    }
}