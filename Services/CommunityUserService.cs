using Microsoft.EntityFrameworkCore;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models;
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
            var commUserConnectedIsAdmin = IsAdmin(userId, community.CommunityId);

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

        public async Task<Result<CommunityUserDTO>> AddUserToCommunity(string userId, CommunityDTO community, UserDTO userToAdd)
        {
            var commUserConnectedIsAdmin = IsAdmin(userId, community.CommunityId);

            if (commUserConnectedIsAdmin == null && !community.IsPublic)
                return new Result<CommunityUserDTO>(false, "User is not an admin of this community and cannot add anyone", null, StatusCodes.Status401Unauthorized);
            
            var isUserInCommunity = await _context.CommunitiesUsers
                                            .AnyAsync(cu => (cu.UserId == userId && cu.CommunityId == community.CommunityId));

            if(isUserInCommunity)
                return new Result<CommunityUserDTO>(false, "User is already in the community",null,StatusCodes.Status409Conflict);

            var modelToInsert = new CommunitiesUsers 
            { 
                CommunityId = community.CommunityId,
                UserId = userToAdd.UserId,
                UserIsAdmin = false
            };

            await _context.CommunitiesUsers.AddAsync(modelToInsert);
            await _context.SaveChangesAsync();

            return new Result<CommunityUserDTO>
                (
                    true,
                    "User added to community",
                    new CommunityUserDTO 
                    {
                        CommunityId = community.CommunityId,
                        CommunityName = community.CommunityName,
                        UserId= userToAdd.UserId,
                        Username = userToAdd.UserName,
                    }
                );
        }

        public Task<Result<CommunityUserDTO>> RemoveAdminFromCommunity(string userId, CommunityDTO community, UserDTO userToDemote)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommunityUserDTO>> RemoveUserFromCommunity(string userId, CommunityDTO community, UserDTO userToRemove)
        {
            throw new NotImplementedException();
        }


        private async Task<bool> IsAdmin(string userId,string communityId) 
        {
            return await _context.CommunitiesUsers
               .AnyAsync(cu => (cu.UserId == userId && cu.CommunityId == communityId) && cu.UserIsAdmin);
        }

        private async Task<bool> IsUserAllowedToAddAsync(string userId, CommunityDTO community)
        {
            bool isAdmin = await IsAdmin(userId, community.CommunityId);
            return isAdmin || community.IsPublic;
        }
    }
}
