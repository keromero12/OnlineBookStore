using System.Collections.Concurrent;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services;

public class DatabaseService
{
    private readonly AuthContext _ctx;
    public ConcurrentDictionary<int, UserModel?> Users { get; } = new();

    public DatabaseService()
    {
        var options = new DbContextOptions<AuthContext>();
        _ctx = new AuthContext(options);
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        _ctx.Database.EnsureCreated();
        RefreshUsers();
        AddUser(new UserModel
        {
            Email = "admin@kitapdukkani.com",
            Password = "12345",
            Token = "dummyToken123",
            Remember = true,
        });
    }

    private void RefreshUsers()
    {
        Users.Clear();
        _ctx.UserModels.ToList().ForEach(u => Users.TryAdd(u.UserId, u));
    }

    public bool AddUser(UserModel? user)
    {
        if (user == null)
            return false;
        if (GetUserByEmail(user.Email) != null)
            return false;
        _ctx.UserModels.Add(user);
        _ctx.SaveChanges();
        RefreshUsers();
        return true;
    }

    public bool UpdateUser(UserModel? user)
    {
        if (user == null)
            return false;
        if (GetUserByEmail(user?.Email) == null)
            return false;
        _ctx.UserModels.Update(user);
        _ctx.SaveChanges();
        RefreshUsers();
        return true;
    }

    public bool DeleteUser(UserModel? user)
    {
        if (user == null)
            return false;
        if (GetUserByEmail(user?.Email) == null)
            return false;
        _ctx.UserModels.Remove(user);
        _ctx.SaveChanges();
        RefreshUsers();
        return true;
    }

    public UserModel? GetUserByEmail(string? email) => _ctx.UserModels.FirstOrDefault(u => u.Email == email);
}