using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface ICommunityService
    {
        public Task<Result<CreateCommunityDTO>> CreateCommunity(string userId,string username,CreateCommunityDTO dto);

        public Task<Result<UpdatedCommunityDTO>> UpdateCommunity(string userId,CommunityDTO communityDTO, UpdatedCommunityDTO updatedCommunityDTO);

        public Task<Result<CommunityDTO>> DeleteCommunity(CommunityDTO communityDTO);
    }
}
