using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    public class UserChat
    {
        [Column(TypeName ="varchar(40)")]
        public string ChatId { get; set; }
        public string ChatName { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string UserId { get; set; }
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public Chat Chat { get; set; }

        public User User { get; set; }


    }
}
