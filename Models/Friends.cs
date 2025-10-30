using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(UserSenderId),nameof(UserReceiverId))]
    public class Friends
    {
        [Column(TypeName ="Varchar(40)")]
        public string UserSenderId { get; set; }

        [Column(TypeName = "Varchar(40)")]
        public string UserReceiverId { get; set; }
        [Column(TypeName = "Varchar(40)")]
        public string UserSenderUsername { get; set; }

        [Column(TypeName = "Varchar(40)")]
        public string UserReceiverUsername { get; set; }
        public bool RequestAccepted { get; set; }

        public  User UserSender {  get; set; }

        public User UserReceiver { get; set; }
    }
}
