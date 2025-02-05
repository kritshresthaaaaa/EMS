using Employee_Management_System.Application.Services.Authentication;
using Employee_Management_System.Application.Services.Department;
using Employee_Management_System.Application.Services.Employee;
using Microsoft.Extensions.DependencyInjection;

namespace Employee_Management_System.Application.Configuration
{
    public static class ConfigurationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
