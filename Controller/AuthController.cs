using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthController(IJwtService jwtService, IUserService userService) 
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRegisterUserDTO dto)
        {
            var user = await _userService.ValidateUser(dto);
            if (user == null) return Unauthorized(new { message = "Authentication error" });

            
            var token = _jwtService.GenerateToken(user.Id,user.UserName, expireHours: 1); 
            return Ok(new
            {
                token,
                expiration = DateTime.UtcNow.AddHours(1)
            });
        }
    }
}
