using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface IChatService
    {
        public Task<Result<ChatDTO>> CreateChat(string currentUserId,CreateChatDTO create);
        public Task<Result<ChatDTO>> DeleteChat(string currentUserId, DeleteChatDTO delete);

        public Task<Result<ChatDTO>> LeaveChat(string currentUserId, LeaveChatDTO leave);
        public Task<Result<ModifiedChatDTO>> ModifyChat (string currentUserId, ModifiedChatDTO modify);
    }
}
