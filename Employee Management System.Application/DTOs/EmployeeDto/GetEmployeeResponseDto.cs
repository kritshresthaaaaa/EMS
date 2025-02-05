namespace Employee_Management_System.Application.DTOs.EmployeeDto
{
    public class GetEmployeeResponseDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
