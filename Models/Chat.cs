using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(ChatId))]
    public class Chat
    {
        public required string ChatId { get; set; }

        public required string ChatName { get; set; }

        public byte[] ChatPicture { get; set; }

        public DateTime ChatCreationDate { get; set; }
    }
}
