namespace Org.Legal.Models
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public Employee? Manager { get; set; }

        public Employee()
        {
            this.EmployeeID = Guid.NewGuid();
            this.Manager = null;
        }
    }


}