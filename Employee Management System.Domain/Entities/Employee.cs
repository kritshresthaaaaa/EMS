namespace Employee_Management_System.Domain.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
