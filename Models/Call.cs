using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(CallId))]
    public class Call
    {
        [Column(TypeName = "Varchar(40)")]
        public string CallId { get; set; }

        public DateTime CallStart { get; set; }

        public DateTime CallEnd { get; set; }
    }
}
