using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace TalkThroughAPI.Models
{

    public enum Type 
    {
        Voice,
        Text
    }

    [PrimaryKey(nameof(Id),nameof(CommunityId))]
    public class Channels
    {
        [Column(TypeName = "varchar(40)")]
        public string Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string CommunityId { get; set; }

        public string ChannelName { get; set; }

        public Type ChatType { get; set; }

        public Communities Community { get; set; }

        public ICollection<Messages> messages { get; set; }
    }
}
