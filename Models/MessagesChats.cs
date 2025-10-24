using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(ChatId), nameof(MessageId))]
    public class MessagesChats
    {
        [Column(TypeName = "Varchar(40)"),ForeignKey("Chat")]
        public string ChatId { get; set; }

        public Chat Chat   { get; set; }

        [Column(TypeName = "Varchar(40)"),ForeignKey("Message")]
        public string MessageId { get; set; }

        public Messages Message { get; set; }
    }
}
