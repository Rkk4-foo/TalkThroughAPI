using System.Drawing;

namespace TalkThroughAPI.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class LoginRegisterUserDTO 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }

}
