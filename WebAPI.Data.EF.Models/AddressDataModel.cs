using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.EF.Models
{
    public class AddressDataModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }

        public virtual EmployeeDataModel Employee { get; set; }
    }
}
