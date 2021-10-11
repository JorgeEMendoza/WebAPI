namespace WebAPI.Models.User
{
    public class UserInDb
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string[] phone_numbers { get; set; }
    }
}