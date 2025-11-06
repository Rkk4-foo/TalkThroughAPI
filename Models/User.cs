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

        public string Salt { get; set; }
    }
}
