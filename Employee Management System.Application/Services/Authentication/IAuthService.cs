using Employee_Management_System.Application.Common.Model;
using Employee_Management_System.Application.DTOs.AuthDto;

namespace Employee_Management_System.Application.Services.Authentication
{
    public interface IAuthService
    {
        GenericResponse<AuthResponse> AuthenticateAsync(AuthRequestDto request);
    }
}
