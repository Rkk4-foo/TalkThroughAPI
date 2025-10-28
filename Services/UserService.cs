using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
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
        private readonly IJwtService _jwt;
        public UserService (Data.TthroughContext context, IWebHostEnvironment env, IJwtService jwt) 
        {
            _context = context;
            _env = env;
            _jwt = jwt;
        }

        public async Task<UserDTO> GetUserAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
                throw new Exception("Usuario no encontrado");

            return new UserDTO 
            {
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                CreationDate = user.AccountCreationDate,
            };
        }

        public async Task<User> ValidateUser(LoginRegisterUserDTO dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == dto.UserName);
            if (user == null || !VerifyPassword(dto.Password, user.Password, user.Salt))
                throw new Exception("Usuario o contraseña incorrecto");

            return user;
            
        }

        public async Task<UserDTO> UserRegister(LoginRegisterUserDTO userDTO)
        {
            MediaService ms = new MediaService();

            var defaultPicturePath = Path.Combine(_env.ContentRootPath, "wwwroot", "Images", "DefaultPicture.png");
            var pfp = ms.GetDefaultImageBytes(defaultPicturePath);
            var (hash, salt) = HashPwd(userDTO.Password);
            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userDTO.UserName,
                DisplayName = userDTO.UserName,
                Password = hash,
                AccountCreationDate = DateTime.Now,
                UserProfilePicture = ms.GetDefaultImageBytes(defaultPicturePath),
                Salt = salt
            };

            if (await _context.Users.AnyAsync(u => u.UserName == user.UserName))
                throw new Exception("This username already exists");   
            _context.Users.Add(user);
            
             await _context.SaveChangesAsync();

            return new UserDTO
            {
                UserName = userDTO.UserName,
                DisplayName = userDTO.UserName,
                CreationDate = DateTime.Now
            };
            
        }

        private (string hashed,string salt) HashPwd(string pwd) 
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string saltBase64 = Convert.ToBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pwd,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return (hashed,saltBase64);
        }

        private bool VerifyPassword(string pwd, string expectedpwd, string saltBase64)
        {
            byte[] storedSalt = Convert.FromBase64String(saltBase64);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pwd,
            salt: storedSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed == expectedpwd;
        }
    }
}
