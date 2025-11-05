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

        /// <summary>
        /// Gets an user
        /// </summary>
        /// <param name="username">User selected username</param>
        /// <returns>Status code of the request and data of the user</returns>
        [HttpGet("users")]
        public async Task<IActionResult> GetUser([FromQuery] string username) 
        {
            var result = await _userService.GetUserAsync(username);
            if(!result.Success)
                return StatusCode(result.StatusCode,result);


            return StatusCode(result.StatusCode, result);
        }

        
        /// <summary>
        /// Registers a new user in the database
        /// </summary>
        /// <param name="dto">New user login credentials</param>
        /// <returns>Data of the new user</returns>
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
