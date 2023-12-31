using Grpc.Core;
using Auth.Services;
using AuthService.Models;

namespace AuthService.Services;

// AuthService server kullanımı için gerekli olan implementasyon sınıfı AuthServiceBase'den türetiliyor 
// AuthServiceBase sınıfı gRPC servislerinin temel sınıfıdır ve proto dosyasında tanımlanan tüm servisler bu sınıftan türetilir
// Projede AuthServiceBase sınıfı AuthService.cs dosyasında tanımlanmıştır
// proto dosyasında tanımlanmış olan servislerin implementasyonu için AuthServiceBase sınıfından türetilen AuthService sınıfı kullanılır

public class AuthService : Auth.Services.AuthService.AuthServiceBase
{
    private readonly DatabaseService
        _databaseService; // DatabaseService sınıfı kullanımı için _databaseService nesnesi oluşturulur

    // AuthService sınıfı constructor metodu
    public AuthService(DatabaseService databaseService)
    {
        _databaseService =
            databaseService; // DatabaseService sınıfı kullanımı için _databaseService nesnesi constructor metodu içerisinde dependency injection ile oluşturulur
    }

    // Login metodu AuthServiceBase sınıfında tanımlanmıştır
    // Override edilerek AuthService servisine özel implementasyonu sağlanır
    // Login metodu kullanıcı girişi için kullanılır
    public override Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var user = _databaseService.GetUserByEmail(request.Email);
        if (user == null)
            return Task.FromResult(new LoginResponse
            {
                Error = "Kullanıcı bulunamadı",
                Token = "",
                Successful = false
            });

        if (user.Password == request.Password)
            return Task.FromResult(new LoginResponse
            {
                Error = "",
                Token = "dummyToken123",
                Successful = true
            });

        return Task.FromResult(new LoginResponse
        {
            Error = "Hatalı şifre",
            Token = "",
            Successful = false
        });
    }

    public override Task<RegisterResponse> Register(RegisterRequest request, ServerCallContext context)
    {
        var user = new UserModel
        {
            Email = request.Email,
            Password = request.Password
        };
        if (_databaseService.AddUser(user))
            return Task.FromResult(new RegisterResponse
            {
                Error = "",
                Successful = true
            });

        return Task.FromResult(new RegisterResponse
        {
            Error = "Kullanıcı zaten kayıtlı",
            Successful = false
        });
    }
}