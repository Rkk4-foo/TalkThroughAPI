using TalkThroughAPI.Models;

namespace TalkThroughAPI.DTO
{
    public class ChatDTO
    {
        public string ChatId { get; set; }

        public string ChatName { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class CreateChatDTO 
    {
        public string ChatName { get; set; }

        public List<User> UserIds { get; set; }
    }

    public class SelectedChatDTO 
    {
        public string ChatId { get; set; }
        public List<User> UserIds { get; set; }
    }
}
