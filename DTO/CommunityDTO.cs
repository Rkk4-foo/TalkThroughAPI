using Microsoft.Identity.Client;

namespace TalkThroughAPI.DTO
{
    public class CommunityDTO
    {
        public string CommunityId{ get; set; }
        public string CommunityName { get; set; }
    }

    public class CreateCommunityDTO 
    {
        public string CommunityName { get; set; }
        public bool IsPublic { get; set; }
    }

    public class UpdatedCommunityDTO 
    {
        public string CommunityId { get; set; }
        public string CommunityName { get; set; }

        public byte[] UpdatedCommunityAvatar { get; set; }

        public bool IsPublic { get; set; }
    }
}