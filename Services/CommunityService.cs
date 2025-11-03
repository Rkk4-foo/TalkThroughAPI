using Microsoft.EntityFrameworkCore;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly TthroughContext _context;

        public CommunityService(TthroughContext context) 
        {
            _context = context;
        }

        public async Task<Result<CreateCommunityDTO>> CreateCommunity(string userId,string username,CreateCommunityDTO dto)
        {
            var communityToCreate = new Communities
            {
                CommunityId = Guid.NewGuid().ToString(),
                CommunityName = dto.CommunityName,
                IsPublic = dto.IsPublic,
                CommunityPicture = null
            };

            var communityUser = new CommunitiesUsers
            {
                CommunityId = communityToCreate.CommunityId,
                UserName = username,
                UserId = userId,
                UserIsAdmin = true,
            };

            await _context.Communities.AddAsync(communityToCreate);
            await _context.CommunitiesUsers.AddAsync(communityUser);
            await _context.SaveChangesAsync();

            return new Result<CreateCommunityDTO>(
                    true,
                    "Community successfully created",
                    dto
                );
        }

        public async Task<Result<CommunityDTO>> DeleteCommunity(CommunityDTO communityDTO)
        {
            var communityToDelete = await _context.Communities.FirstOrDefaultAsync(c => c.CommunityId == communityDTO.CommunityId); ;

            if (communityToDelete == null)
                return new Result<CommunityDTO>
                    (
                        false,
                        "Communty doesn't exist. Cannot delete",
                        communityDTO,
                        StatusCodes.Status404NotFound
                    );
            _context.Communities.Remove( communityToDelete );
            await _context.SaveChangesAsync();

            return new Result<CommunityDTO>
                (
                    true,
                    "Community deleted",
                    communityDTO
                );
        }


        /// <summary>
        /// Allows the user to update the community. The method checks if the user is admin and has privileges inside the community to update it.
        /// Update option should'nt be visible to non admins but just in case.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="communityDTO"></param>
        /// <param name="updatedCommunityDTO"></param>
        /// <returns></returns>
        public async Task<Result<UpdatedCommunityDTO>> UpdateCommunity(string userId,CommunityDTO communityDTO, UpdatedCommunityDTO updatedCommunityDTO)
        {
            var community = await _context.Communities.FirstOrDefaultAsync(c => c.CommunityId == communityDTO.CommunityId);

            var usersCommunity = await _context.CommunitiesUsers.FirstOrDefaultAsync(uc => uc.CommunityId == community.CommunityId && uc.UserId == userId);

            if (community == null)
                return new Result<UpdatedCommunityDTO>
                    (
                        false,
                        "Community doesn't exist. Cannot update",
                        null,
                        StatusCodes.Status404NotFound
                    );

            if (!usersCommunity.UserIsAdmin)
                return new Result<UpdatedCommunityDTO>
                    (
                        false,
                        "User is not an admin of this community, cannot update",
                        null,
                        StatusCodes.Status409Conflict
                    );

            return new Result<UpdatedCommunityDTO>
                (
                    true,
                    "Community updated succesfully",
                    updatedCommunityDTO
                );
        }
    }
}
