using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(ChatId))]
    public class Chat
    {
        [Column(TypeName = "Varchar(40)")]
        public required string ChatId { get; set; }

        public required string ChatName { get; set; }

        public byte[] ChatPicture { get; set; }

        public DateTime ChatCreationDate { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
