using ReportManagementAPI.Domain;
using System.Security.Claims;

namespace ReportManagementAPI.Application
{
    public interface IAuthService
    {
        ClaimsIdentity GenerateClaims(User user);
        string GenerateToken(User user);

        User AuthenticateUser(string email, string password);
    }
}