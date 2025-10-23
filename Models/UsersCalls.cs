using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    public class UsersCalls
    {

        [Column(TypeName = "Varchar2(40)")]
        public required string CallId { get; set; }
        [Column(TypeName = "Varchar2(40)")]
        public required string UserId { get; set; }

        public Calls Calls { get; set; }

        public User Users { get; set; }
    }
}
