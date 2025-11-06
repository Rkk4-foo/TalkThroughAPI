using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Migrations;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Controller
{
    [ApiController]
    [Route("{controller}/Community-Management")]
    public class CommunityUserController : ControllerBase
    {
        private readonly ICommunityUserService _communityUserService;
        private readonly string _userId;
        public CommunityUserController(ICommunityUserService communityUserService)
        {
            _communityUserService = communityUserService;
            _userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        [Authorize]
        [HttpGet("Admin-Check")]
        public async Task<IActionResult> GetUserAdminStatus([FromQuery] CommunityDTO community)
        {
            
            if (_userId == null)
                return NotFound();


            var result = await _communityUserService.UserIsAdmin(_userId, community);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPut("Add-Admin")]
        public async Task<IActionResult> PutAdminInCommunity([FromBody] UserDTO userToPromote, CommunityDTO comm)
        {
            

            if (_userId == null)
                return NotFound();

            var result = await _communityUserService.AddAdminToCommunity(_userId, userToPromote, comm);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPost("Add-User")]
        public async Task<IActionResult> PostUserInCommunity([FromBody] UserDTO userToAdd, CommunityDTO comm)
        {
            
            if (_userId == null)
                return NotFound();

            var result = await _communityUserService.AddUserToCommunity(_userId, comm, userToAdd);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpDelete("Remove-User")]
        public async Task<IActionResult> DeleteUserCommunity([FromBody] CommunityDTO comm, UserDTO userToRemove) 
        {
            if (_userId == null) 
                return NotFound();

            var result = await _communityUserService.RemoveUserFromCommunity(_userId, comm, userToRemove);
            if(!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPut("demote-user")]
        public async Task<IActionResult> DemoteUser([FromBody] CommunityDTO community,UserDTO user) 
        {
           if(_userId==null)
                return NotFound();

           var result = await _communityUserService.RemoveAdminFromCommunity(_userId, community, user);
            if(!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode,result);

        }
    }
}
