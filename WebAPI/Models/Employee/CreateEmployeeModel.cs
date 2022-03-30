using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Employee
{
    public class CreateEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateEmployeeModel(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }
    }
}
