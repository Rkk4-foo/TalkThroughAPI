using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    public class Messages
    {
        [Key,Column(TypeName = "Varchar2(40)")]
        public required string MessageId { get; set; }
        public string MessageContent { get; set; }
        [Column(TypeName = "TimeStamp")]
        public TimeSpan MessageSentTime { get; set; }        
        public IList<MessagesChats> MessagesChats {  get; set; }

    }
}
