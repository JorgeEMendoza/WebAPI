using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.Models.User;
using WebAPI.Repositories.Contracts;
using static MongoDB.Driver.Builders<MongoDB.Bson.BsonDocument>;

namespace WebAPI.Repositories.Implementations
{
    public class MongoUserRepoImp : IMongoUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<UserInDb> _collection;

        public MongoUserRepoImp()
        {
            IMongoClient mongoClient = new MongoClient("mongodb://mongoDBAdmin:mongoDBAdmin@192.168.2.220:27017/?authSource=admin");
            _mongoDatabase = mongoClient.GetDatabase("TestDB");
            _collection = _mongoDatabase.GetCollection<UserInDb>("Users");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = new List<User>();
            
            List<UserInDb> usersInDb = await _collection.Find(new BsonDocument()).ToListAsync();

            foreach (UserInDb user in usersInDb)
            {
                users.Add(new User
                {
                    Id = user._id.ToString(),
                    FirstName = user.name,
                    LastName = user.last_name,
                    PhoneNumbers = user.phone_numbers
                    
                });
            }

            return users;
        }

        public async Task<User> GetUserByName(string name)
        {
            var filter = Filter.Eq("name", name);
            var userInDb = await _collection.Find(new BsonDocument("name", name)).FirstAsync();
            var user = new User
            {
                Id = userInDb._id.ToString(),
                FirstName = userInDb.name,
                LastName = userInDb.last_name,
                PhoneNumbers = userInDb.phone_numbers
            };
                
            return user;
        }

    }
}