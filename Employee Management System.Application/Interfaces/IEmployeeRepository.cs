using Employee_Management_System.Application.DTOs.EmployeeDto;

namespace Employee_Management_System.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<GetEmployeeResponseDto>> GetAllEmployeesAsync();
        Task<GetEmployeeResponseDto> GetEmployeeByIdAsync(int employeeId);
        Task AddEmployeeAsync(Domain.Entities.Employee employee);
        Task UpdateEmployeeAsync(Domain.Entities.Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
