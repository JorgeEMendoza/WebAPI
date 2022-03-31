using System;

namespace WebAPI.Models
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
