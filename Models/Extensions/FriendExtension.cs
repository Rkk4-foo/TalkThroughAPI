using TalkThroughAPI.DTO;

namespace TalkThroughAPI.Models.Extensions
{
    public static class FriendExtension
    {
        public static FriendDTO ToFriendDTO(this Friends friend,string currentUserId) 
        {
            bool isFriendDTO = friend.UserSenderId == currentUserId;

            return new FriendDTO
            {
                UserId = friend.UserSenderId == currentUserId ? friend.UserReceiverId : friend.UserSenderId,
                Username = friend.UserSenderId == currentUserId ? friend.UserReceiverUsername : friend.UserSenderUsername,
                UserAvatar = null
            };
        }

        public static FriendRequestDTO ToFriendRequestDTO(this Friends friend) 
        {
            return new FriendRequestDTO
            {
                UserSenderId = friend.UserSenderId,
                UserReceiverId = friend.UserReceiverId,
                SenderUsername = friend.UserSenderUsername,
                ReceiverUsername = friend.UserReceiverUsername
            };
        }
    }
}
