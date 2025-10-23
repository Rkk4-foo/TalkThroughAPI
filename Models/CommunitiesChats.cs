using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(IdChat),nameof(IdCommunity))]
    public class CommunitiesChats
    {
        [Column(TypeName = "Varchar2(40)"),ForeignKey("Chat")]
        public required string IdChat { get; set; }
        [Column(TypeName = "Varchar2(40)"),ForeignKey("Community")]
        public required string IdCommunity { get; set; }
        public required Chat Chat { get; set; }
        public required Communities Community { get; set; }
    }
}
