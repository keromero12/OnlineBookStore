using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Models;

[Table("UserModel")]
public class UserModel
{
    [Key]
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; } = "dummyToken123";
    public bool Remember { get; set; }
}

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
            optionsBuilder.UseSqlite(connectionString);
            
        }
    }

    public DbSet<UserModel> UserModels { get; set; }
}