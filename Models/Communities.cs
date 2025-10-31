using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(CommunityId))]
    public class Communities
    {
        [Column(TypeName = "varchar(40)")]
        public required string CommunityId { get; set; }
        public required string CommunityName {get; set;}
        public byte[]? CommunityPicture { get; set; }

        public bool IsPublic { get; set; }
       
    }
}
