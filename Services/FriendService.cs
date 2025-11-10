using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TalkThroughAPI.Data;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;
using TalkThroughAPI.Models.Extensions;
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

            return Result<List<FriendDTO>>.SuccessR(friends, "list of friends");
        }

        public async Task<Result<FriendRequestDTO>> SendFriendRequest(string userId, string username)
        {
            var userSender = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var userRequest = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            bool isFriendAlready = await _context.Friends
            .AnyAsync(f =>
                (f.UserSenderId == userId && f.UserReceiverId == userRequest.Id) ||
                (f.UserSenderId == userRequest.Id && f.UserReceiverId == userId) && f.RequestAccepted);

            if (isFriendAlready)
                return Result<FriendRequestDTO>.Failure("Users are already friends");
                
            else
            {
                var friendRequest = new FriendRequestDTO
                {
                    UserSenderId = userId,
                    UserReceiverId = userRequest.Id,
                    SenderUsername = userSender.UserName,
                    ReceiverUsername = userRequest.UserName
                };

                var friend = new Models.Friends
                {
                    UserReceiverId = userRequest.Id,
                    UserSenderId = userSender.Id,
                    UserReceiverUsername = userRequest.UserName,
                    UserSenderUsername = userSender.UserName
                };

                _context.Friends.Add(friend);
                await _context.SaveChangesAsync();

                return Result<FriendRequestDTO>.SuccessR(friend.ToFriendRequestDTO(),"Friend request sent");
            }
        }

        public async Task<Result<FriendRequestDTO>> AcceptFriendRequest(string userId, string username)
        {
            var friendRequest = await _context.Friends
               .FirstOrDefaultAsync(f => (f.UserSenderId == userId && f.UserReceiverUsername == username && !f.RequestAccepted)
               || (f.UserReceiverId == userId && f.UserSenderUsername == username && !f.RequestAccepted));

            if (friendRequest == null)
                return Result<FriendRequestDTO>.Failure("Friend request does not exist",default,"FRIEND_NOT_EXISTANT");


            if (friendRequest.RequestAccepted)
                return Result<FriendRequestDTO>.Failure("Friend request already accepted", default, "FRIEND_REQUEST_CONFLICT");
                

            friendRequest.RequestAccepted = true;
            await _context.SaveChangesAsync();

            return Result<FriendRequestDTO>.SuccessR(friendRequest.ToFriendRequestDTO(),"Friend request accepted");
        }

        public async Task<Result<FriendRequestDTO>> DenyFriendRequest(string userId, string username)
        {
            var friendRequest = await _context.Friends
               .FirstOrDefaultAsync(f => (f.UserSenderId == userId && f.UserReceiverUsername == username && f.RequestAccepted)
               || (f.UserReceiverId == userId && f.UserSenderUsername == username && f.RequestAccepted));

            if (friendRequest == null)
                return new Result<FriendRequestDTO>(false, "Friend request does not exist", null, StatusCodes.Status404NotFound);

            _context.Friends.Remove(friendRequest);
            await _context.SaveChangesAsync();

            return Result<FriendRequestDTO>.SuccessR(friendRequest.ToFriendRequestDTO(),"Friend request denied");

        }

        public async Task<Result<FriendDTO>> RemoveFriend(string userId, string username) 
        {
            var friendship = await _context.Friends
                .FirstOrDefaultAsync(f => (f.UserSenderId == userId && f.UserReceiverUsername == username && f.RequestAccepted) 
                || (f.UserReceiverId == userId && f.UserSenderUsername == username && f.RequestAccepted));

            if (friendship == null)
                return Result<FriendDTO>.Failure("Friend does not exist", StatusCodes.Status404NotFound, "FRIEND_NON_EXISTANT");

            _context.Friends.Remove(friendship);
            await _context.SaveChangesAsync();

            return Result<FriendDTO>.SuccessR( friendship.ToFriendDTO(userId),"Friend removed");
        }
    }
}
