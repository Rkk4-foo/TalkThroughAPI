using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(MessageId))]
    public class Messages
    {
        [Column(TypeName = "Varchar(40)")]
        public required string MessageId { get; set; }
        public string MessageContent { get; set; } 
        public DateTime MessageSentTime { get; set; }        
        public IList<MessagesChats> MessagesChats {  get; set; }

    }
}
