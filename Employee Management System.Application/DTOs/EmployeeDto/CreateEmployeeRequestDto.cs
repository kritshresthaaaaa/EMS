namespace Employee_Management_System.Application.DTOs.EmployeeDto
{
    public class CreateEmployeeRequestDto
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
