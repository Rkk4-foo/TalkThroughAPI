using System.Drawing;
using TalkThroughAPI.Models;

namespace TalkThroughAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();

        public Task<User> GetUserById(string id);

        public void UserRegister(string username, string pwd,Image defaultUserImage);
    }
}
