using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportManagementAPI.Application;
using ReportManagementAPI.Domain;
using System.Security.Cryptography.X509Certificates;
using ReportManagementAPI.API.DTOs;

namespace ReportManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllercs : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthControllercs(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            User user = _authService.AuthenticateUser(model.Email, model.Password);

            var token = _authService.GenerateToken(user);
            return Ok(token);
        }
    }
}
