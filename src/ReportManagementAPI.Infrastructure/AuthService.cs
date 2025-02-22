﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ReportManagementAPI.Domain;
using Microsoft.IdentityModel.Tokens;
using ReportManagementAPI.Application;

namespace ReportManagementAPI.Infrastructure
{
    public class AuthService : IAuthService
    {
        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthSettings.PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        public ClaimsIdentity GenerateClaims(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            foreach (var role in user.Roles)
                claims.AddClaim(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        public User AuthenticateUser(string email, string password)
        {
            User user = new(Guid.NewGuid(), string.Empty, email, password, ["User"]);

            return user;
        }
    }
}
