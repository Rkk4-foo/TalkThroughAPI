using System.Drawing;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models.Common;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Result<UserDTO>> GetUserAsync(string username);

        public Task<Result<UserDTO>> UserRegister(LoginRegisterUserDTO userDTO);

        public Task<Result<Models.User>> ValidateUser(LoginRegisterUserDTO loginDTO);
    }
}
