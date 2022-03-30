using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Employee
{
    public class Employee_Main
    {
        [Key]
        public int Emp_ID { get; set; }
        public string EMP_FirstName { get; set; }
        public string EMP_LastName { get; set; }
        public DateTime? EMP_BirthDate { get; set; }
        public string EMP_PhoneNumber { get; set; }
        public string EMP_Address { get; set; }
    }
}
