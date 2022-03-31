namespace WebAPI.Data.EF.Models
{
    public class PhoneNumberDataModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual EmployeeDataModel Employee { get; set; }
    }
}
