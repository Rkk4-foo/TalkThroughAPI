using TalkThroughAPI.DTO;

namespace TalkThroughAPI.Models.Extensions
{
    public static class CommunityExtension
    {
        public static CommunityDTO ToCommunityDTO(this Communities comm) 
        {
            return new CommunityDTO 
            {
                CommunityId = comm.CommunityId,
                CommunityName = comm.CommunityName,
                IsPublic = comm.IsPublic,
            };
        }

        public static CreateCommunityDTO ToCreateCommunityDTO(this Communities comm) 
        {
            return new CreateCommunityDTO 
            {
                CommunityName = comm.CommunityName,
                IsPublic = comm.IsPublic
            };
        }

        public static UpdatedCommunityDTO ToUpdatedCommunityDTO(this Communities comm) 
        {
            return new UpdatedCommunityDTO 
            {
                CommunityId = comm.CommunityId,
                CommunityName = comm.CommunityName,
                UpdatedCommunityAvatar = comm.CommunityPicture,
                IsPublic = comm.IsPublic
            };
        }
    }
}
