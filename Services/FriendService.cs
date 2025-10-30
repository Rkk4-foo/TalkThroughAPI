using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Services.Interfaces;

namespace TalkThroughAPI.Services
{
    public class FriendService : IFriendService
    {
        private readonly TthroughContext _context;

        public FriendService(TthroughContext context)
        {
            _context = context;
        }

        public async Task<Result<List<FriendDTO>>> GetAllUserFriends(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var friendships = await _context.Friends
                .Where(f => (f.UserSenderId == userId || f.UserReceiverId == userId) && f.RequestAccepted)
                .Include(f => f.UserSender)
                .Include(f => f.UserReceiver)
                .ToListAsync();

            var friends = friendships.Select(f =>
            {
                var friend = f.UserSenderId == userId ? f.UserReceiver : f.UserSender;
                return new FriendDTO
                {
                    UserId = userId,
                    Username = friend.UserName,
                    UserAvatar = friend.UserProfilePicture
                };
            }).ToList();

            return new Result<List<FriendDTO>>(
                true,
                "Friends obtained correctly",
                friends
                );
        }

        public async Task<Result<FriendRequestDTO>> SendFriendRequest(string userId, string username)
        {
            var userSender = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var userRequest = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            bool isFriendAlready = await _context.Friends
            .AnyAsync(f =>
                f.UserSenderId == userId && f.UserReceiverId == userRequest.Id ||
                f.UserSenderId == userRequest.Id && f.UserReceiverId == userId);

            if (isFriendAlready)
                return new Result<FriendRequestDTO>(false, "Users are already friends",null,StatusCodes.Status409Conflict);
            else
            {
                var friendRequest = new FriendRequestDTO
                {
                    UserSenderId = userId,
                    UserReceiverId = userRequest.Id,
                    SenderUsername = userSender.UserName,
                    ReceiverUsername = userRequest.UserName
                };



                _context.Friends.Add(new Models.Friends
                {
                    UserReceiverId = userRequest.Id,
                    UserSenderId = userSender.Id,
                    UserReceiverUsername = userRequest.UserName,
                    UserSenderUsername = userSender.UserName
                });
                await _context.SaveChangesAsync();

                return new Result<FriendRequestDTO>(
                    true,
                    "Friend Request sent correctly",
                    new FriendRequestDTO
                    {
                        UserSenderId = userId,
                        UserReceiverId = userRequest.Id,
                        SenderUsername = userSender.UserName,
                        ReceiverUsername = userRequest.UserName
                    });
            }
        }
    }
}
