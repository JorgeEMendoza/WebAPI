using System;
using System.Collections.Generic;

namespace WebAPI.Models.User
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] PhoneNumbers { get; set; }
    }
}