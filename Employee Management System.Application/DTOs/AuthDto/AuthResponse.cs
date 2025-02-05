namespace Employee_Management_System.Application.DTOs.AuthDto
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
