using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalkThroughAPI.DTO;

using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Controller
{
    [ApiController]
    [Route("Community/Community-Management")]
    public class CommunityUserController : ControllerBase
    {
        private readonly ICommunityUserService _communityUserService;
        private readonly string _userId;
        public CommunityUserController(ICommunityUserService communityUserService)
        {
            _communityUserService = communityUserService;
            _userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        /// <summary>
        /// Gets if the user is an admin in the specified community
        /// </summary>
        /// <param name="community">Communnity where the check happens</param>
        /// <returns>Status code of the request and a boolean</returns>
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
        
        /// <summary>
        /// Gives an user in the community admin status
        /// </summary>
        /// <param name="userToPromote">User that's going to be promoted to admin</param>
        /// <param name="comm">Community where the user is going to be promoted</param>
        /// <returns>Status of the user after the request</returns>
        [Authorize]
        [HttpPut("Add-Admin")]
        public async Task<IActionResult> PutAdminInCommunity([FromQuery] UserDTO userToPromote, CommunityDTO comm)
        {
            

            if (_userId == null)
                return NotFound();

            var result = await _communityUserService.AddAdminToCommunity(_userId, userToPromote, comm);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Adds user to the community
        /// </summary>
        /// <param name="userToAdd">User info for the user to add</param>
        /// <param name="comm">Community where the user is going to be added</param>
        /// <returns>Information from the request</returns>
        [Authorize]
        [HttpPost("Add-User")]
        public async Task<IActionResult> PostUserInCommunity([FromQuery] UserDTO userToAdd, CommunityDTO comm)
        {
            
            if (_userId == null)
                return NotFound();

            var result = await _communityUserService.AddUserToCommunity(_userId, comm, userToAdd);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Removes user from the community
        /// </summary>
        /// <param name="comm">Community where the specified user is going to be deleted from</param>
        /// <param name="userToRemove">User that is going to be removed</param>
        /// <returns>Status code in the request and all the data from the encapsulated result</returns>
        [Authorize]
        [HttpDelete("Remove-User")]
        public async Task<IActionResult> DeleteUserCommunity([FromQuery] CommunityDTO comm, UserDTO userToRemove) 
        {
            if (_userId == null) 
                return NotFound();

            var result = await _communityUserService.RemoveUserFromCommunity(_userId, comm, userToRemove);
            if(!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Demotes user that was once an admin
        /// </summary>
        /// <param name="community">Community user is going to be demoted</param>
        /// <param name="user">User that is going to be demoted</param>
        /// <returns>Status of the request and status of the community and the user after the request</returns>
        [Authorize]
        [HttpPut("demote-user")]
        public async Task<IActionResult> DemoteUser([FromQuery] CommunityDTO community,UserDTO user) 
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
