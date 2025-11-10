using TalkThroughAPI.DTO;

namespace TalkThroughAPI.Models.Extensions
{
    public static class UserExtension
    {
        public static UserDTO toUserDTO(this User user) 
        {
            return new UserDTO 
            {
                UserId = user.Id,
                UserName = user.UserName,
                CreationDate = user.AccountCreationDate,
                DisplayName = user.DisplayName
            };
        }

        public static LoginRegisterUserDTO toLoginRegisterDTO(this User user) 
        {
            return new LoginRegisterUserDTO 
            {
                UserName = user.UserName,
                Password = user.Password,
            };
        }
    }
}
