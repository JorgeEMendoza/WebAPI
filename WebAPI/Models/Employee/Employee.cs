namespace WebAPI.Models.Employee
{
    public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Employee()
        {
            this.ID = 1;
            this.FirstName = "Jorge";
            this.LastName = "Mendoza";

        }
    }
}
