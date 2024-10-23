using ReportManagementAPI.Domain;
using ReportManagementAPI.Application;
using ReportManagementAPI.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<AuthService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthCore API", Version = "v1" });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthCore API V1");
    });
}

app.MapPost("/authenticate", (User user, AuthService authService)
    => authService.GenerateToken(user));

app.Run();