using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Models
{
    public class ChatsUser
    {
        public required string IdChat { get; set; }
        public required Chats Chat { get; set; } 
        public required string UserId { get; set; }
        public required User User { get; set; }
    }
}
