using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface IChatService
    {
        public Task<Result<ChatDTO>> CreateChat(string currentUserId,CreateChatDTO create);
        public Task<Result<SelectedChatDTO>> DeleteChat(string currentUserId, ChatDTO delete);
    }
}
