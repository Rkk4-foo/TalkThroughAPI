using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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


    public class  LeaveChatDTO
    {
        public string ChatId{ get; set; }

        public List<User> UserIds { get; set; }
    }

    public class DeleteChatDTO 
    {
        public string ChatId { get; set; }

        public List<User> UserIds { get; set; }
    }

    public class ModifiedChatDTO 
    {
        public string ChatId { get; set; }

        public string NewChatName { get; set; }
    }
}
