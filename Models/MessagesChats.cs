using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    public class MessagesChats
    {
        [Column(TypeName = "Varchar2(40)")]
        public string ChatId { get; set; }

        public Chats Chat   { get; set; }

        [Column(TypeName = "Varchar2(40)")]
        public string MessageId { get; set; }

        public Messages message { get; set; }
    }
}
