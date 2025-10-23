

namespace TalkThroughAPI.Models
{
    public class CommunitiesUsers
    {
        public string CommunityID { get; set; }

        public Communities Community { get; set; }

        public string UserID { get; set; }

        public User User { get; set; }
    }
}
