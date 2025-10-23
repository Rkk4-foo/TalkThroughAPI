using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TalkThroughAPI.Models
{
    public class Friends
    {
        [Key]
        public User UserSender { get; set; }

        public User Receiver { get; set; }

        public bool RequestAccepted { get; set; }
    }
}
