using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(UserSenderId),nameof(UserReceiverId))]
    public class Friends
    {
        public string UserSenderId { get; set; }

        public string UserReceiverId { get; set; }

        public bool RequestAccepted { get; set; }

        public required User UserSender {  get; set; }

        public required User UserReceiver { get; set; }
    }
}
