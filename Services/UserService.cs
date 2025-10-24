using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using TalkThroughAPI.Models;

namespace TalkThroughAPI.Services
{
    public class UserService : Interfaces.IUserService
    {
        Data.TthroughContext  _context;

        public UserService (Data.TthroughContext context) 
        {
            _context = context;
        }

        public Task<List<User>> GetAllUsers()
        {
            var users = _context.Users.ToListAsync();
            return users;
        }

        public Task<User> GetUserById(string id)
        {
            var user = _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public void UserRegister(string username, string pwd, Image defaultPicture)
        {
            MediaService ms = new MediaService();

            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = username,
                DisplayName = username,
                Password = HashPwd(pwd),
                UserProfilePicture = ms.ImageToByteArray(defaultPicture),
                AccountCreationDate = DateTime.Now
            };

            _context.Users.Add(user);
        }

        private string HashPwd(string pwd) 
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pwd,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
