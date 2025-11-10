using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Models.Extensions;
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

            using var transaction = _context.Database.BeginTransaction();

            try
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

                await _context.Channels.AddRangeAsync(CreateDefaultChannels(communityToCreate.CommunityId));
                await _context.SaveChangesAsync();


                return Result<CreateCommunityDTO>.SuccessR(communityToCreate.ToCreateCommunityDTO(), "Community creation succeded");

            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync();
                return Result<CreateCommunityDTO>.Failure($"Error creating community{ex.Message}");
            }
        }

        public async Task<Result<CommunityDTO>> DeleteCommunity(CommunityDTO communityDTO)
        {
            var communityToDelete = await _context.Communities.FindAsync(communityDTO.CommunityId);

            if (communityToDelete == null)
                return Result<CommunityDTO>.Failure("Community doesn't exist",StatusCodes.Status404NotFound,"CMT_NOT_EXIST");

            _context.Communities.Remove( communityToDelete );
            await _context.SaveChangesAsync();

            return Result<CommunityDTO>.SuccessR(communityToDelete.ToCommunityDTO(),"Community deleted succesfully");
        }


        private List<Channels> CreateDefaultChannels(string communityId)
        {
            return new()
            {
                new Channels { Id = Guid.NewGuid().ToString(), CommunityId = communityId, ChannelName = "General", ChatType = Models.Type.Text},
                new Channels { Id = Guid.NewGuid().ToString(), CommunityId = communityId, ChannelName = "General", ChatType = Models.Type.Voice}
            };
        }

    }
}
