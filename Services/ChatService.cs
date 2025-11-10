using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Services
{

    /// <summary>
    ///Handles chat-related operations
    ///Although chat creation and management are user-driven actions
    ///this service is i solated from its user counterpant to maintain separation of concerns
    /// </summary>
    public class ChatService : IChatService
    {
        private readonly TthroughContext _context;
        public ChatService(TthroughContext context) 
        {
            _context = context;
        }

        public Task<Result<ChatDTO>> CreateChat(string currentUserId, CreateChatDTO create)
        {
            throw new NotImplementedException();
        }
    }
}
