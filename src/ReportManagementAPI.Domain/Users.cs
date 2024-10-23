using System;

namespace ReportManagementAPI.Domain;

public record User
{
    public Guid Id { get; init; } = Guid.NewGuid(); 
    public string Name { get; init; } = string.Empty; 
    public string Email { get; init; } = string.Empty; 
    public string Password { get; init; } = string.Empty; 
    public string[] Roles { get; init; } = Array.Empty<string>(); 

    public User(Guid id, string name, string email, string password, string[] roles)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Roles = roles ?? Array.Empty<string>();
    }
}
