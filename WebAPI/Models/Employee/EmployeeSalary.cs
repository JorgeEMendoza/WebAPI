using System;
using System.ComponentModel.DataAnnotations;
namespace WebAPI.Models.Employee
{
    public class EmployeeSalary
    {
        [Key]
        public int Id { get; set; }

        public int EId { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
    }
}
