using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Controller
{

    [ApiController]
    [Route("api/Communities")]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityService _communityService;

        public CommunityController(ICommunityService service)
        {
            _communityService = service;
        }

        /// <summary>
        /// Creates a community and makes the creator admin
        /// </summary>
        /// <param name="dto">Communities values introduced in the GUI</param>
        /// <returns>Status code of the result and all the info regarding the result</returns>
        [HttpPost("CreateCommunity")]
        public async Task<IActionResult> PostCommunity([FromBody] CreateCommunityDTO dto) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            if(username == null || userId == null)
                return NotFound();

            var result = await _communityService.CreateCommunity(userId,username,dto);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }
    }
}
