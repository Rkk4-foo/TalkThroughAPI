using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface IFriendService
    {
        public Task<Result<List<FriendDTO>>> GetAllUserFriends(string userId);

        public Task<Result<FriendRequestDTO>> SendFriendRequest(string userId,string username);

        public Task<Result<FriendRequestDTO>> AcceptFriendRequest(string userId, string username);

        public Task<Result<FriendRequestDTO>> DenyFriendRequest (string userId, string username);
    }
}
