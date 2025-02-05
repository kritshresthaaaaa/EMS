using Employee_Management_System.Application.Common.Model;
using Employee_Management_System.Application.Common.Model.Error;
using Employee_Management_System.Application.Common.Model.Pagination;
using Employee_Management_System.Application.DTOs.DepartmentDto;
using Employee_Management_System.Application.Extensions;
using Employee_Management_System.Application.Interfaces;

namespace Employee_Management_System.Application.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Response> AddDepartmentAsync(CreateDepartmentRequestDto request)
        {
            var department = new Domain.Entities.Department
            {
                DepartmentName = request.DepartmentName
            };
            await _departmentRepository.AddDepartmentAsync(department);
            return new Response();
        }

        public async Task<GenericResponse<IEnumerable<GetDepartmentResponseDto>>> GetAllDepartmentsAsync()
        {
            var response = (await _departmentRepository.GetAllDepartmentsAsync()).ToList().Select(d => new GetDepartmentResponseDto
            {
                DepartmentID = d.DepartmentID,
                DepartmentName = d.DepartmentName,                
            }).ToList();
            return response;

        }

        public async Task<GenericResponse<GetDepartmentResponseDto>> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return new ErrorModel(System.Net.HttpStatusCode.BadRequest, "Department not found");
            }
            var response = new GetDepartmentResponseDto
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName
            };
            return response;
        }
    }
}
