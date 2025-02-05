using Employee_Management_System.Application.Interfaces;

namespace Employee_Management_System.Infrastructure.Data.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public DepartmentRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task AddDepartmentAsync(Domain.Entities.Department department)
        {
            await _sqlDataAccess.SaveData("dbo.sp_AddDepartment", new { department.DepartmentName });
        }

        public async Task DeleteDepartmentAsync(int departmentId)
        {
            await _sqlDataAccess.SaveData("dbo.sp_DeleteDepartment", new { departmentId });
        }

        public async Task<IEnumerable<Domain.Entities.Department>> GetAllDepartmentsAsync()
        {
            
            return await _sqlDataAccess.GetData<Domain.Entities.Department, dynamic>("dbo.sp_GetAllDepartments", new { });
        }

        public async Task<Domain.Entities.Department> GetDepartmentByIdAsync(int departmentId)
        {
            var result = await _sqlDataAccess.GetData<Domain.Entities.Department, dynamic>("dbo.sp_GetDepartmentById", new { departmentId });
            return result.FirstOrDefault();
        }

        public async Task UpdateDepartmentAsync(Domain.Entities.Department department)
        {
            await _sqlDataAccess.SaveData("dbo.sp_UpdateDepartment", new { department.DepartmentID, department.DepartmentName });
        }
    }
}
