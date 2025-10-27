using System.Drawing;
using TalkThroughAPI.DTO;


namespace TalkThroughAPI.Services.Interfaces
{
    public interface IUserService
    {
        public  Task<List<DTO.UserDTO>> GetAllUsers();

        public Task<DTO.UserDTO> GetUserById(string id);

        public Task<UserDTO> UserRegister(CreateUserDTO userDTO);
    }
}
