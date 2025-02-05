using Employee_Management_System.Application.Common.Model;
using Employee_Management_System.Application.Common.Model.Pagination;
using Employee_Management_System.Application.DTOs.EmployeeDto;

namespace Employee_Management_System.Application.Services.Employee
{
    public interface IEmployeeService
    {
        Task<GenericResponse<PaginatedListResponse<GetEmployeeResponseDto>>> GetAllEmployeesAsync(FilterEmployeeRequestDto request);
        Task<GenericResponse<GetEmployeeResponseDto>> GetEmployeeByIdAsync(int id);
        Task<Response> AddEmployeeAsync(CreateEmployeeRequestDto request);
        Task<Response> UpdateEmployeeAsync(UpdateEmployeeRequestDto request);
        Task<Response> DeleteEmployeeAsync(int id);
    }
}
