using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Employee
{
    [Flags]
    public enum EmployeeValidationErrors
    {
        None = 0,
        ModelIsNull = 1 << 0,
        FirstNameMissing = 1 << 1,
        LastNameMissing = 1 << 2
    }
}
