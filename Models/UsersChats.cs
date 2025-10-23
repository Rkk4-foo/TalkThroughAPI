using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(ChatId), nameof(UserId))]
    public class UsersChats
    {
        [ForeignKey("Chat"), Column(Order = 1, TypeName = "varchar(40)")]
        public string ChatId{ get; set; }

        [ForeignKey("Usuario"), Column(Order = 1, TypeName = "varchar(40)")]
        public string UserId { get; set; }

        public User User { get; set; }

        public Chat Chat { get; set; }
    }
}
