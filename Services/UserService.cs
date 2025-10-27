using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using TalkThroughAPI.DTO;
using TalkThroughAPI.Models;
using TalkThroughAPI.Services.Interfaces;


namespace TalkThroughAPI.Services
{
    public class UserService : Interfaces.IUserService
    {
        private readonly Data.TthroughContext  _context;
        private readonly IWebHostEnvironment _env;

        public UserService (Data.TthroughContext context, IWebHostEnvironment env) 
        {
            _context = context;
            _env = env;
        }

        public Task<List<UserDTO>> GetAllUsers()
        {
            return  _context.Users
            .Select(u => new UserDTO
            { 
                UserName = u.UserName,
                DisplayName = u.DisplayName,
                CreationDate = u.AccountCreationDate
            })
            .ToListAsync();
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);

            return new UserDTO
            {

                UserName = user.UserName,
                DisplayName = user.DisplayName,
                CreationDate = user.AccountCreationDate
            };
        }

        public async Task<UserDTO> UserRegister(CreateUserDTO userDTO)
        {
            MediaService ms = new MediaService();

            var defaultPicturePath = Path.Combine(_env.ContentRootPath, "wwwroot", "Images", "DefaultPicture.png");
            var pfp = ms.GetDefaultImageBytes(defaultPicturePath);

            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userDTO.UserName,
                DisplayName = userDTO.UserName,
                Password = HashPwd(userDTO.Password),
                AccountCreationDate = DateTime.Now,
                UserProfilePicture = ms.GetDefaultImageBytes(defaultPicturePath)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                UserName = userDTO.UserName,
                DisplayName = userDTO.UserName,
                CreationDate = DateTime.Now
            };
            
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
