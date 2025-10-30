namespace TalkThroughAPI.DTO
{
    public class FriendDTO
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public byte[] UserAvatar { get; set; }
    }

    public class FriendRequestDTO 
    {
        public string UserSenderId { get; set; }

        public string UserReceiverId { get; set; }

        public string SenderUsername { get; set; }

        public string ReceiverUsername { get; set; }
    }
}
