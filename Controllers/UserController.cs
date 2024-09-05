using KDSOrderManagement.Models.Dtos;
using KDSOrderManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KDSOrderManagement.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        [SwaggerOperation(
            Summary = "Register user",
            Description = "Register user",
            OperationId = "Register user",
            Tags = new[] { "Users" }
        )]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            try
            {
                var token = await _userService.CreateAsync(userDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [HttpPost("login")]
        [SwaggerOperation(
            Summary = "Authenticate user",
            Description = "Authenticate user",
            OperationId = "Authenticate user",
            Tags = new[] { "Users" }
        )]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            try
            {
                var token = await _userService.AuthenticateAsync(userDto);

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }
    }
}
