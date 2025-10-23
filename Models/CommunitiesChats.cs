using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    public class CommunitiesChats
    {
        [Column(TypeName = "Varchar2(40)")]
        public required string IdChat { get; set; }
        [Column(TypeName = "Varchar2(40)")]
        public required string IdCommunity { get; set; }
        public required Chats chat { get; set; }
        public required Communities Community { get; set; }
    }
}
