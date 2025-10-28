using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(ChatId), nameof(UserId))]
    public class UsersChats
    {
        [Column(TypeName = "varchar(40)")]
        public string ChatId{ get; set; }

        [Column(TypeName = "varchar(40)")]
        public string UserId { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string UserName { get; set; }
        public User User { get; set; }

        public Chat Chat { get; set; }
    }
}
