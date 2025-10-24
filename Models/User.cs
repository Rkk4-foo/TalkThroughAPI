using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class User
    {
        [Column(TypeName = "Varchar(40)")]
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public string? DisplayName { get; set; }
        public required string Password { get; set; }
        [Column(TypeName = "VARBINARY(MAX)")]
        public required byte[]? UserProfilePicture { get; set; }
        public required DateTime AccountCreationDate { get; set; }
        public required DateTime LastLoginTime { get; set; }
        public enum UserStatus
        {
            Conectado = 1,
            Ausente = 2,
            NoMolestar = 3,
            Desconectado = 0

        }
    }
}
