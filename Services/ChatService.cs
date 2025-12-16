using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Transactions;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models;
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

        /// <summary>
        /// Handles creation of chats. Supports creation of 1:1 chats and group chats.
        /// To discern between a 1:1 chat and a group chat the number of users
        /// added to the chat must be counted.
        /// 
        /// TODO - Add a view DBSide in order to make easier groups management
        /// </summary>
        /// <param name="currentUserId">Current user id provided by the token.</param>
        /// <param name="create">List of users that participate in the chat and chat name.</param>
        /// <returns>Chat information and StatusCode of the request encapsulated on a return record.</returns>

        public async Task<Result<ChatDTO>> CreateChat(String currentUserId, CreateChatDTO create) 
        {
            throw new NotImplementedException();
        }

        //public async Task<Result<ChatDTO>> CreateChat(string currentUserId, CreateChatDTO create)
        //{
        //    var userIds = create.UserIds.Select(u => u.Id).Distinct().ToList();

        //    if (!userIds.Contains(currentUserId))
        //        userIds.Add(currentUserId);

        //    var users = await _context.Users
        //        .Where(u => userIds.Contains(u.Id))
        //        .ToListAsync();

        //    if (users.Count != userIds.Count)
        //        return Result<ChatDTO>.Failure(
        //            "Some users do not exist in DB",
        //            StatusCodes.Status400BadRequest,
        //            "USER_NON_EXISTANT"
        //        );

        //    if (users.Count > 2)
        //    {
        //        var chat = new Chat
        //        {
        //            ChatId = Guid.NewGuid().ToString(),

        //        };
        //    }

    }
}
