using Auth.Services;

namespace BookstoreWebApp.Services;

public interface IAuthService
{
    bool IsUserLoggedIn();
    string GetUserName();
    Task<LoginResponse> Login(LoginRequest request);
    Task Logout();
    Task<RegisterResponse> Register(RegisterRequest request);
}
