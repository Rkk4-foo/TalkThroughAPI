using Microsoft.AspNetCore.Mvc;
using TalkThroughAPI.DTO;


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
        
        public async Task<IActionResult> GetAllUsers() 
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id) 
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);        
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] LoginRegisterUserDTO dto) 
        {
            try
            {
                var user = await _userService.UserRegister(dto);
                return Ok(user);
            }
            catch (Exception ex) 
            { 
                return BadRequest(new {message = ex.Message});        
            }
        }

       
    }
}
