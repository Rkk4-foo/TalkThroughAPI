using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface ICommunityUserService
    {
        public Task<Result<CommunityUserDTO>> AddAdminToCommunity(string userId, UserDTO userToPromote, CommunityDTO community);

        public Task<Result<bool>> UserIsAdmin (string userId, CommunityDTO communityDTO);
        public Task<Result<UpdatedCommunityDTO>> UpdateCommunity(string userId, CommunityDTO community,UpdatedCommunityDTO updatedCommunity);
        public Task<Result<CommunityUserDTO>> RemoveAdminFromCommunity(string userId, CommunityDTO community,UserDTO userToDemote);

        public Task<Result<CommunityUserDTO>> AddUserToCommunity(string userId, CommunityDTO community, UserDTO userToAdd);

        public Task<Result<CommunityUserDTO>> RemoveUserFromCommunity(string userId, CommunityDTO community, UserDTO userToRemove);
    }
}