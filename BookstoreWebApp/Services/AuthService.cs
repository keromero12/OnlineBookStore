using Auth.Services;

namespace BookstoreWebApp.Services;

public class AuthService : IAuthService
{
    // This could be replaced with a proper user management service
    private bool _isUserLoggedIn;
    private string _currentUserName;

    private readonly Auth.Services.AuthService.AuthServiceClient
        _client; // gRPC client nesnesi kitap servisine bağlanmak için kullanılacak

    public AuthService(IServiceManager serviceManager)
    {
        // auth servisine bağlanmak için gerekli olan client nesnesi oluşturuluyor
        _client = serviceManager.CreateGrpcClient<Auth.Services.AuthService.AuthServiceClient>("localhost", 30081);
    }

    public bool IsUserLoggedIn() => _isUserLoggedIn;

    public string GetUserName()
    {
        return _currentUserName;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var response = await _client.LoginAsync(request);

        if (response.Successful)
        {
            _isUserLoggedIn = true;
            _currentUserName = request.Email;
        }
        else
        {
            _isUserLoggedIn = false;
        }

        return response;
    }

    public Task Logout()
    {
        // In a real application, you would clear the user session.
        _isUserLoggedIn = false;
        _currentUserName = null;
        return Task.CompletedTask;
    }

    public async Task<RegisterResponse> Register(RegisterRequest request) => await _client.RegisterAsync(request);
}