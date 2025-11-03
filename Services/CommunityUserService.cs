using Microsoft.EntityFrameworkCore;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Services.Interfaces;
namespace TalkThroughAPI.Services
{
    public class CommunityUserService : ICommunityUserService
    {
        private readonly TthroughContext _context;

        public CommunityUserService(TthroughContext context) 
        {
            _context = context;
        }

        public async Task<Result<CommunityUserDTO>> AddAdminToCommunity(string userId, UserDTO userToPromote, CommunityDTO community)
        {
            var commUserConnectedIsAdmin = await _context.CommunitiesUsers
                .FirstOrDefaultAsync(cu => (cu.UserId == userId && cu.CommunityId == community.CommunityId) && cu.UserIsAdmin);

            if (commUserConnectedIsAdmin == null)
                return new Result<CommunityUserDTO>(false, "User is not an admin of this community and cannot promote anyone",null, StatusCodes.Status401Unauthorized);

            var user = await _context.CommunitiesUsers.FirstOrDefaultAsync(cu => cu.UserName == userToPromote.UserName && cu.CommunityId == community.CommunityId);
            if (user == null)
                return new Result<CommunityUserDTO>(false, "User is not in this community anymore", null, StatusCodes.Status409Conflict);


            return new Result<CommunityUserDTO>
                (
                    true,
                    "User promoted to admin correctly",
                    new CommunityUserDTO 
                    {
                        CommunityId = community.CommunityId,
                        CommunityName = community.CommunityName,
                        UserId = userToPromote.UserName,
                        Username = userToPromote.UserName,  
                    }
                );

        }

        public Task<Result<CommunityUserDTO>> AddUserToCommunity(string userId, CommunityDTO community, UserDTO userToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommunityUserDTO>> RemoveAdminFromCommunity(string userId, CommunityDTO community, UserDTO userToDemote)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommunityUserDTO>> RemoveUserFromCommunity(string userId, CommunityDTO community, UserDTO userToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
