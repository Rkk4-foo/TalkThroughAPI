

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(CommunityId),nameof(UserId),nameof(UserName))]
    public class CommunitiesUsers
    {
        [Column(TypeName ="Varchar(40)"),ForeignKey("Community")]
        public string CommunityId { get; set; }

        public Communities Community { get; set; }
        [Column(TypeName = "Varchar(40)")]
        public string UserId { get; set; }
        [Column(TypeName ="Varchar(40)")]
        public string UserName { get; set; }
        public bool UserIsAdmin { get; set; }
        public User User { get; set; }
    }
}
