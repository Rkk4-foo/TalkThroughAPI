using System.Drawing;

namespace TalkThroughAPI.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class CreateUserDTO 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
