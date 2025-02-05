using Employee_Management_System.Application.Common.Model;
using Employee_Management_System.Application.Common.Model.Pagination;
using Employee_Management_System.Application.DTOs.DepartmentDto;

namespace Employee_Management_System.Application.Services.Department
{
    public interface IDepartmentService
    {
        Task<GenericResponse<IEnumerable<GetDepartmentResponseDto>>> GetAllDepartmentsAsync();
        Task<GenericResponse<GetDepartmentResponseDto>> GetDepartmentByIdAsync(int id);
        Task<Response> AddDepartmentAsync(CreateDepartmentRequestDto request);
    }
}
