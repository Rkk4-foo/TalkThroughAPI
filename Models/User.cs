using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(Id),nameof(UserName))]
    public class User
    {
        [Column(TypeName = "Varchar(40)")]
        public required string Id { get; set; }

        [Column(TypeName = "Varchar(40)")]
        public required string UserName { get; set; }
        public string? DisplayName { get; set; }
        [JsonIgnore]
        [Required]
        [MinLength(60)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[_-])(?!.*[A-Z]{2})(?!.*[a-z]{2})(?!.*\d{2})(?!.*[_-]{2})[A-Za-z\d_-]{8,}$",
        ErrorMessage = "Password must be 8 characters long and contain a number, a letter and a ")]
        public  string Password { get; set; }
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[]? UserProfilePicture { get; set; }
        public required DateTime AccountCreationDate { get; set; }
        public DateTime LastLoginTime { get; set; }
        public enum UserStatus
        {
            Connected = 1,
            Away = 2,
            DoNotDisturb = 3,
            Disconnected = 0
        }
        [JsonIgnore]
        [Required]
        [MinLength(16)]
        public string Salt { get; set; }

        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
    }
}
