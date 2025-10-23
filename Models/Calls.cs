using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Models
{
    public class Calls
    {
        public string CallId { get; set; }

        public DateTime CallStart { get; set; }

        public DateTime CallEnd { get; set; }

        public IList<UsersCalls> UsersCalls { get; set; }
    }
}
