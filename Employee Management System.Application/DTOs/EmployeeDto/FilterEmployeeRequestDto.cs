using Employee_Management_System.Domain.Enums;

namespace Employee_Management_System.Application.DTOs.EmployeeDto
{
    public class FilterEmployeeRequestDto
    {
        public string? SearchQuery { get; set; }
        public int? DepartmentId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public EmployeeSortBy SortBy { get; set; } = EmployeeSortBy.Name;
        public bool IsDescending { get; set; }
    }
}
