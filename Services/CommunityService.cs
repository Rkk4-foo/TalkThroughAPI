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
                CommunityPicture = dto.CommunityPicture
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

        public Task<Result<CommunityDTO>> DeleteCommunity(CommunityDTO communityDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommunityDTO>> UpdateCommunity(CommunityDTO communityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
