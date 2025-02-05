
using Employee_Management_System.Application.Common.Model;
using Employee_Management_System.Application.Common.Model.Error;
using Employee_Management_System.Application.Common.Model.Pagination;
using Employee_Management_System.Application.DTOs.EmployeeDto;
using Employee_Management_System.Application.Extensions;
using Employee_Management_System.Application.Interfaces;
using Employee_Management_System.Domain.Entities;
using Employee_Management_System.Domain.Enums;

namespace Employee_Management_System.Application.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Response> AddEmployeeAsync(CreateEmployeeRequestDto request)
        {
            var employee = new Domain.Entities.Employee
            {
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                Salary = request.Salary,
                DateOfJoining = request.DateOfJoining.Date
            };
            await _employeeRepository.AddEmployeeAsync(employee);
            return new Response();
        }

        public async Task<Response> DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return new ErrorModel(System.Net.HttpStatusCode.BadRequest, "Employee not found");
            }

            await _employeeRepository.DeleteEmployee(id);
            return new Response();
        }

        public async Task<GenericResponse<PaginatedListResponse<GetEmployeeResponseDto>>> GetAllEmployeesAsync(FilterEmployeeRequestDto request)
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                var searchQuery = request.SearchQuery.Trim().ToLower();
                employees = employees.Where(e => e.Name.ToLower().Contains(searchQuery));
            }
            if (request.DepartmentId.HasValue)
            {
                employees = employees.Where(e => e.DepartmentId == request.DepartmentId);
            }
            switch (request.SortBy)
            {
                case EmployeeSortBy.Name:
                    employees = request.IsDescending ? employees.OrderByDescending(e => e.Name) : employees.OrderBy(e => e.Name);
                    break;
                case EmployeeSortBy.Department:
                    employees = request.IsDescending ? employees.OrderByDescending(e => e.DepartmentName) : employees.OrderBy(e => e.DepartmentName);
                    break;
                case EmployeeSortBy.Salary:
                    employees = request.IsDescending ? employees.OrderByDescending(e => e.Salary) : employees.OrderBy(e => e.Salary);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Name);
                    break;
            }

            var paginatedEmployees = employees
                .ToPaginatedListResponse(request.PageNumber, request.PageSize);

            return paginatedEmployees;
        }
        public async Task<GenericResponse<GetEmployeeResponseDto>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return new ErrorModel(System.Net.HttpStatusCode.NotFound, "Employee not found");
            }

            return employee;
        }

        public async Task<Response> UpdateEmployeeAsync(UpdateEmployeeRequestDto request)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (existingEmployee == null)
            {
                return new ErrorModel(System.Net.HttpStatusCode.BadRequest, "Employee not found");
            }
            var employee = new Domain.Entities.Employee()
            {
                EmployeeID = request.Id,
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                Salary = request.Salary,
                DateOfJoining = request.DateOfJoining.Date
            };

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return new Response();
        }


    }
}
