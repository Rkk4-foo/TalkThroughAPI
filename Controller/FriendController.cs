using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Controller
{
    [ApiController]
    [Route("/Talkthrough/FriendManagement")]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService) 
        {
            _friendService = friendService;
        }


        /// <summary>
        /// Gets all the friends of the user in the session
        /// </summary>
        /// <returns>Status code and all the parameters from the result</returns>
        [Authorize]
        [HttpGet("GetFriends")]
        public async Task<IActionResult> GetUserFriends() 
        {
            var connUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _friendService.GetAllUserFriends(connUserId);
            if (!result.Success)
                return StatusCode(result.StatusCode,result);

            return StatusCode(result.StatusCode,result);
        }

        /// <summary>
        /// Sends a friend request 
        /// </summary>
        /// <param name="username">Username of the user the friend request is sent to</param>
        /// <returns>Result of the friend request in a encapsulated record.</returns>
        [Authorize]
        [HttpPost("friend-request")]

        public async Task<IActionResult> PostFriendRequest([FromBody] string username) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _friendService.SendFriendRequest(userId, username);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);


            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Accepts a friend request
        /// </summary>
        /// <param name="username">Sender's username</param>
        /// <returns>Result of the friend request with the new "RequestAccepted" parameter</returns>
        [Authorize]
        [HttpPut("friend-request/accept")]
        public async Task<IActionResult> PutFriendAccept([FromBody] string username) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var result = await _friendService.AcceptFriendRequest(userId, username);
            if(!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode,result);
        }
        /// <summary>
        /// Denies a friend request
        /// </summary>
        /// <param name="username">Sender's username</param>
        /// <returns>Result of the deleted friend request register</returns>
        [Authorize]
        [HttpDelete("friend-request/deny")]
        public async Task<IActionResult> DeleteFriendRequest([FromBody] string username) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _friendService.DenyFriendRequest(userId, username);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }
        /// <summary>
        /// Removes user from the friend list
        /// </summary>
        /// <param name="username">User to remove username</param>
        /// <returns>Details about the deleted register fom DB</returns>
        [Authorize]
        [HttpDelete("friend-request/remove-friend")]

        public async Task<IActionResult> RemoveFriend([FromBody] string username) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _friendService.RemoveFriend(userId, username);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }
    }
}
