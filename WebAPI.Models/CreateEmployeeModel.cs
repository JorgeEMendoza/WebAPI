using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class CreateEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public CreateEmployeeModel() { }

        public CreateEmployeeModel(string fName, string lName,
            DateTime? dateOfBirth)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dateOfBirth.HasValue ? dateOfBirth.Value : DateTime.Now;
        }
    }
}
