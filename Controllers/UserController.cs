using KDSOrderManagement.Models;
using KDSOrderManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KDSOrderManagement.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
    }
}
