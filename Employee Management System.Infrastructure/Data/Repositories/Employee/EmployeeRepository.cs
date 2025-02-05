

using Employee_Management_System.Application.DTOs.EmployeeDto;
using Employee_Management_System.Application.Interfaces;

namespace Employee_Management_System.Infrastructure.Data.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ISqlDataAccess _sqlDataAccess;

        public EmployeeRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task AddEmployeeAsync(Domain.Entities.Employee employee)
        {
            await _sqlDataAccess.SaveData("dbo.sp_AddEmployee", new { employee.Name, employee.Salary, employee.DateOfJoining, employee.DepartmentId });
        }

        public async Task<IEnumerable<GetEmployeeResponseDto>> GetAllEmployeesAsync()
        {
            var result = await _sqlDataAccess.GetData<GetEmployeeResponseDto, dynamic>("dbo.sp_GetAllEmployees", new { });
            return result;
        }

        public async Task<GetEmployeeResponseDto> GetEmployeeByIdAsync(int employeeId)
        {
            var result = await _sqlDataAccess.GetData<GetEmployeeResponseDto, dynamic>("dbo.sp_GetEmployeeById", new { employeeId });
            return result.FirstOrDefault();
        }

        public async Task DeleteEmployee(int employeeId)
        {

            await _sqlDataAccess.SaveData("dbo.sp_DeleteEmployee", new { employeeId });
        }

        public async Task UpdateEmployeeAsync(Domain.Entities.Employee employee)
        {

            await _sqlDataAccess.SaveData("dbo.sp_UpdateEmployee", new { employee.EmployeeID, employee.Name, employee.Salary, employee.DateOfJoining, employee.DepartmentId });
        }
    }
}
