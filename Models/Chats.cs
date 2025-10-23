using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Models
{
    public class Chats
    {
        public required string ChatId { get; set; }

        public required string ChatName { get; set; }

        public required IList<ChatsUser> ChatsUser { get; set; }

        public required IList<CommunitiesChats> ChatsCommunities { get; set; }

        public required IList<MessagesChats> MessagesChats { get; set; }
    }
}
