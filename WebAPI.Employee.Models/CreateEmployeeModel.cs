using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class CreateEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<EmployeePhoneNumber> PhoneNumbers { get; set; }
        public List<EmployeeAddress> Addresses { get; set; }

        public CreateEmployeeModel(string fName, string lName,
            DateTime? dateOfBirth,
            List<EmployeePhoneNumber> phoneNumbers,
            List<EmployeeAddress> addresses)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dateOfBirth.HasValue ? dateOfBirth.Value : DateTime.Now;
            this.PhoneNumbers = phoneNumbers;
            this.Addresses = addresses;
        }
    }
}
