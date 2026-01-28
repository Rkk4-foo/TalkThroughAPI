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
            var commUserConnectedIsAdmin = await UserIsAdmin(userId, community);

            if (!commUserConnectedIsAdmin.Data)
                return new Result<CommunityUserDTO>(false, "User is not an admin of this community and cannot promote anyone", null, StatusCodes.Status401Unauthorized);

            var user = await _context.CommunitiesUsers.FirstOrDefaultAsync(cu => cu.UserName == userToPromote.UserName && cu.CommunityId == community.CommunityId);
            if (user == null)
                return new Result<CommunityUserDTO>(false, "User is not in this community anymore", null, StatusCodes.Status409Conflict);


            return new Result<CommunityUserDTO>(
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

            if (!await IsUserAllowedToAddAsync(userId, community))
                return new Result<CommunityUserDTO>(false, "User is not an admin of this community and cannot add anyone", null, StatusCodes.Status401Unauthorized);

            var isUserInCommunity = await _context.CommunitiesUsers
                                            .AnyAsync(cu => (cu.UserId == userId && cu.CommunityId == community.CommunityId));

            if (isUserInCommunity)
                return Result<CommunityUserDTO>.Failure("User is already in the community", StatusCodes.Status400BadRequest, "USER_COMM_CONFLICT");

            var modelToInsert = new CommunitiesUsers
            {
                CommunityId = community.CommunityId,
                UserId = userToAdd.UserId,
                UserIsAdmin = false
            };

            await _context.CommunitiesUsers.AddAsync(modelToInsert);
            await _context.SaveChangesAsync();


            return Result<CommunityUserDTO>.SuccessR(
                new CommunityUserDTO
                {
                    CommunityId = community.CommunityId,
                    CommunityName = community.CommunityName,
                    UserId = userToAdd.UserId,
                    Username = userToAdd.UserName,
                },
                "User added to community"
            );
        }

        public async Task<Result<CommunityUserDTO>> JoinCommunity(string userId, string communityId)
        {
            var userJoining = await _context.Users.FindAsync(userId);
            if (userJoining == null)
                return Result<CommunityUserDTO>.Failure("Couldn't find requested user", StatusCodes.Status404NotFound, "USER_NOT_FOUND");

            var commToJoin = await _context.Communities.FindAsync(communityId);
            if (commToJoin == null)
                return Result<CommunityUserDTO>.Failure("Couldn't find requested community", StatusCodes.Status404NotFound, "COMM_NOT_FOUND");

            var modelToInsert = new CommunitiesUsers 
            {
                CommunityId = communityId,
                UserId = userId,
                UserIsAdmin = false
            };

            await _context.CommunitiesUsers.AddAsync(modelToInsert);
            await _context.SaveChangesAsync();

            return Result<CommunityUserDTO>.SuccessR
                (
                new CommunityUserDTO 
                {
                    CommunityId = communityId,
                    UserId = userId,
                    CommunityName = commToJoin.CommunityName,
                    Username = userJoining.UserName
                },
                "Congratulations! Welcome to" + commToJoin.CommunityName

                );

        }

        public async Task<Result<CommunityUserDTO>> RemoveAdminFromCommunity(string userId, CommunityDTO community, UserDTO userToDemote)
        {
            var commUserConnectedIsAdmin = await UserIsAdmin(userId, community);

            if (!commUserConnectedIsAdmin.Data)
                return Result<CommunityUserDTO>.Failure("User is not an admin", default, "NOT_ALLOWED");

            var toDemote = await UserIsAdmin(userToDemote.UserId, community);

            if (!toDemote.Data)
                return Result<CommunityUserDTO>.Failure("User to demote is not an admin", StatusCodes.Status400BadRequest, "USER_NOT_ADMIN");

            var userToDemoteFromTable = await _context.CommunitiesUsers.FindAsync(userToDemote.UserId, community.CommunityId, userToDemote.UserName);

            if (userToDemoteFromTable == null)
                return Result<CommunityUserDTO>.Failure("User to demote does not exist", StatusCodes.Status400BadRequest, "USER_NOT_ADMIN");


            userToDemoteFromTable.UserIsAdmin = false;
            await _context.SaveChangesAsync();

            return Result<CommunityUserDTO>.SuccessR(
                    new CommunityUserDTO
                    {
                        CommunityId = community.CommunityId,
                        CommunityName = community.CommunityName,
                        UserId = userToDemote.UserId,
                        Username = userToDemote.UserName
                    },
                    "User demoted"
            );
        }

        public async Task<Result<CommunityUserDTO>> RemoveUserFromCommunity(string userId, CommunityDTO community, UserDTO userToRemove)
        {
            var resultIsAdmin = await UserIsAdmin(userId, community);

            if (!resultIsAdmin.Data)
                return Result<CommunityUserDTO>.Failure("user is not admin",StatusCodes.Status401Unauthorized,"USER_NOT_ADMIN");

            var user = await _context.CommunitiesUsers
                .FirstOrDefaultAsync(cu => cu.CommunityId == community.CommunityId && cu.UserId == userToRemove.UserId);

            if (user == null)
                return Result<CommunityUserDTO>.Failure("User does not exist", StatusCodes.Status404NotFound, "USER_NOT_FOUND");

            _context.CommunitiesUsers.Remove(user);
            await _context.SaveChangesAsync();

            return Result<CommunityUserDTO>.SuccessR(
                    new CommunityUserDTO
                    {
                        CommunityId = community.CommunityId,
                        CommunityName = community.CommunityName,
                        UserId = userToRemove.UserId,
                        Username = userToRemove.UserName
                    },
                    "User removed successfully"
                );
        }

        public async Task<Result<UpdatedCommunityDTO>> UpdateCommunity(string userId, CommunityDTO community, UpdatedCommunityDTO updatedCommunity)
        {
            var result = await UserIsAdmin(userId, community);

            if (!result.Data)
                return Result<UpdatedCommunityDTO>.Failure("User is admin and cannot change community parameters", StatusCodes.Status401Unauthorized, "USER_NOT_ADMIN");

            var communityUser = await _context.CommunitiesUsers
                .Include(cu => cu.Community)
                .FirstOrDefaultAsync(cu => cu.CommunityId == community.CommunityId && cu.UserId == userId);

            if(communityUser == null || communityUser.Community == null)
                return Result<UpdatedCommunityDTO> .Failure("User not in community or data unavailable",StatusCodes.Status404NotFound,"DATA_UNAVAILABLE");

            communityUser.Community.CommunityName = updatedCommunity.CommunityName;
            communityUser.Community.CommunityPicture = updatedCommunity.UpdatedCommunityAvatar;
            communityUser.Community.IsPublic = updatedCommunity.IsPublic;

            await _context.SaveChangesAsync();

            return Result<UpdatedCommunityDTO>.SuccessR(updatedCommunity, "Community updated successfully");

        }
        public async Task<Result<bool>> UserIsAdmin(string userId, CommunityDTO communityDTO)
        {
            var isAdmin = await _context.CommunitiesUsers
               .AnyAsync(cu => (cu.UserId == userId && cu.CommunityId == communityDTO.CommunityId) && cu.UserIsAdmin);

            return Result<bool>.SuccessR(isAdmin, "");
        }

        private async Task<bool> IsUserAllowedToAddAsync(string userId, CommunityDTO community)
        {
            var result = await UserIsAdmin(userId, community);
            return result.Data || community.IsPublic;
        }

        
    }
}
