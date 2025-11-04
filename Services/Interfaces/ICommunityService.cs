using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface ICommunityService
    {
        public Task<Result<CreateCommunityDTO>> CreateCommunity(string userId,string username,CreateCommunityDTO dto);

        
    }
}
