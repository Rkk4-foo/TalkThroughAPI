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

            return Result<CreateCommunityDTO>.SuccessR(dto, "Community creation succeded");
        }

        public async Task<Result<CommunityDTO>> DeleteCommunity(CommunityDTO communityDTO)
        {
            var communityToDelete = await _context.Communities.FindAsync(communityDTO.CommunityId);

            if (communityToDelete == null)
                return Result<CommunityDTO>.Failure("Community doesn't exist",StatusCodes.Status404NotFound,"CMT_NOT_EXIST");

            _context.Communities.Remove( communityToDelete );
            await _context.SaveChangesAsync();

            return Result<CommunityDTO>.SuccessR(communityDTO,"Community deleted succesfully");
        }


        
        
    }
}
