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
        public byte[] CommunityPicture { get; set; }
    }
}
