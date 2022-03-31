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

        public Employee() { }
        
        public Employee(string fName, string lName, IEnumerable<EmployeePhoneNumber> phoneNumbers, IEnumerable<EmployeeAddress> addresses, DateTime? dateOfBirth = null)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dateOfBirth.Value.ToUniversalTime();

        }

    }
}
