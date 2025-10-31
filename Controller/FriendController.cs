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
