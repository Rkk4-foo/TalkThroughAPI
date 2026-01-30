using System.Runtime.CompilerServices;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Services;

namespace TalkThroughAPI.Models.Extensions
{
    public static class ChatExtension
    {
        public static ChatDTO toChatDTO(this Chat chat) 
        {
            return new ChatDTO
            {
                ChatId = chat.ChatId,
                ChatName = chat.ChatName,
            };
        }
    }
}
