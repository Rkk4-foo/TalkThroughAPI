using Microsoft.EntityFrameworkCore;

namespace TalkThroughAPI.Data
{
    public class TthroughContext : DbContext
    {
        public TthroughContext(DbContextOptions<TthroughContext> options) : base(options)
        {
        }

        public DbSet<Models.User> Users{ get; set; }
        public DbSet<Models.Chats> Chats{ get; set; }
        public DbSet<Models.Messages> Messages{ get; set; }
        public DbSet<Models.Communities> Communities{ get; set; }
        public DbSet<Models.ChatsUser> ChatsUsers{ get; set; }
        public DbSet<Models.MessagesChats> MessagesChats{ get; set; }
        public DbSet<Models.CommunitiesChats> CommunitiesChats { get; set; }
        public DbSet<Models.Calls> Calls { get; set; }
        public DbSet<Models.UsersCalls> UsersCalls { get; set; }
        public DbSet<Models.CommunitiesUsers> CommunitiesUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
