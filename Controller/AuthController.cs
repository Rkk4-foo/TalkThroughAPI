using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;
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
            var result = await _userService.ValidateUser(dto);
            if (!result.Success) 
                return StatusCode(result.StatusCode,result);

            
            var token = _jwtService.GenerateToken(result.Data.Id,result.Data.UserName, expireHours: 1);
            return Ok(new Result<object>(
                true,
                "Login exitoso",
                new
                {
                   token,
                   expiration = DateTime.UtcNow.AddHours(1)
                }    
            ));
        }
    }
}
