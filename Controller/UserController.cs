using Microsoft.AspNetCore.Mvc;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;


namespace TalkThroughAPI.Controller
{
    [ApiController]
    [Route("/Talkthrough/UserManagement")]
    public class UserController : ControllerBase
    {
        private Services.Interfaces.IUserService _userService;

        public UserController(Services.Interfaces.IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUser([FromQuery] string username) 
        {
            var result = await _userService.GetUserAsync(username);
            if(!result.Success)
                return StatusCode(result.StatusCode,result);


            return StatusCode(result.StatusCode, result);
        }

        

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] LoginRegisterUserDTO dto) 
        {
            var result = await _userService.UserRegister(dto);
            if(!result.Success)
                return StatusCode(result.StatusCode,result);

            return StatusCode(result.StatusCode, result);
        }
    }
}
