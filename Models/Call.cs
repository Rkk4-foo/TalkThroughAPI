using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Models
{
    [PrimaryKey(nameof(CallId))]
    public class Call
    {
        public string CallId { get; set; }

        public DateTime CallStart { get; set; }

        public DateTime CallEnd { get; set; }
    }
}
