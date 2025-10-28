using System.Drawing;
using TalkThroughAPI.DTO;


namespace TalkThroughAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserAsync(string username);

        public Task<UserDTO> UserRegister(LoginRegisterUserDTO userDTO);

        public Task<Models.User> ValidateUser(LoginRegisterUserDTO loginDTO);
    }
}
