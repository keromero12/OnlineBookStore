using AuthService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<DatabaseService>();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();

app.UseRouting();
app.UseGrpcWeb();
app.UseCors();
app.UseEndpoints(routeBuilder => routeBuilder
    .MapGrpcService<AuthService.Services.AuthService>()
    .EnableGrpcWeb()
    .RequireCors("AllowAll"));

// Configure the HTTP request pipeline.
app.MapGet("/", () => "");
app.Run();