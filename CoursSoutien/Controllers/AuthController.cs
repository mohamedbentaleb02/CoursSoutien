using Microsoft.AspNetCore.Mvc;
using CoursSoutien.Application.Interfaces;
using CoursSoutien.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CoursSoutien.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            try
            {
                var result = await authService.RegisterAsync(request);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            try
            {
                var token = await authService.LoginAsync(request);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { Error = "Identifiants invalides." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await authService.GetAvailableRolesAsync();
            return Ok(roles);
        }
    }
}