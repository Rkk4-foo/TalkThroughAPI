using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Channels;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(MessageId))]
    public class Messages
    {
        [Column(TypeName = "Varchar(40)")]
        public required string MessageId { get; set; }
        public DateTime SentAt { get; set; }

        public string? ChannelId { get; set; }
        public string? ChatId { get; set; }
        public string SenderId { get; set; }
        public virtual Channels? Channel { get; set; }
        public virtual Chat? Chat { get; set; }
        public virtual User Sender { get; set; }
    }
}
