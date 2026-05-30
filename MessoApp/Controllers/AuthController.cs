
using MessoApp.DTO.RequestModels;
using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [ApiController]

    [Route("api/v1/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var token = await _authService.LoginAsync(request);
            return Ok(token);
        }

    }
}
