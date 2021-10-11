using MongoDB.Bson;

namespace WebAPI.Models.User
{
    public class UserRequest
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}