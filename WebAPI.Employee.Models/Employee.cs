using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IEnumerable<EmployeePhoneNumber> PhoneNumbers { get; set; }
        public IEnumerable<EmployeeAddress> Addresses { get; set; }

        public Employee() { }
        
        public Employee(string fName, string lName, IEnumerable<EmployeePhoneNumber> phoneNumbers, IEnumerable<EmployeeAddress> addresses, DateTime? dateOfBirth = null,)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dateOfBirth.HasValue ? dateOfBirth.Value() : null;

        }

    }
}
