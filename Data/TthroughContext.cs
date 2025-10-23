using Microsoft.EntityFrameworkCore;
using TalkThroughAPI.Models;

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
        public DbSet<Models.Friends> Friends { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChatsUser>()
            .HasKey(cu => new { cu.UserId, cu.IdChat });

            modelBuilder.Entity<ChatsUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.ChatsUser)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<ChatsUser>()
                .HasOne(cu => cu.Chat)
                .WithMany(c => c.ChatsUser)
                .HasForeignKey(cu => cu.IdChat);

            modelBuilder.Entity<UsersCalls>().HasKey(uc => new { uc.UserId,uc.CallId});

            modelBuilder.Entity<UsersCalls>()
                .HasOne(uc => uc.Calls)
                .WithMany(c => c.UsersCalls)
                .HasForeignKey(uc => uc.CallId);
        }
    }
}
