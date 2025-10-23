using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(CommunityId)]
    public class Communities
    {  
        public required string CommunityId { get; set; }
        public required string CommunityName {get; set;}
        public byte[]? ComunnityPicture { get; set; }
       
    }
}
