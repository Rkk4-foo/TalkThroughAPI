using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(CallId),nameof(UserId))]
    public class UsersCalls
    {

        [Column(TypeName = "Varchar(40)"),ForeignKey("Calls")]
        public required string CallId { get; set; }
        [Column(TypeName = "Varchar(40)"),ForeignKey("Users")]
        public required string UserId { get; set; }

        public Call Calls { get; set; }

        public User Users { get; set; }
    }
}
