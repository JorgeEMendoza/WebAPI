using System;
using System.Collections.Generic;

namespace WebAPI.Data.EF.Models
{
    public class EmployeeDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual IEnumerable<PhoneNumberDataModel> PhoneNumbers { get; set; }
        public virtual IEnumerable<AddressDataModel> Addresses { get; set; }
    }
}
