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
        public DbSet<Models.Chat> Chats{ get; set; }
        public DbSet<Models.Messages> Messages{ get; set; }
        public DbSet<Models.Communities> Communities{ get; set; }
        public DbSet<Models.UsersChats> ChatsUsers{ get; set; }
        public DbSet<Models.MessagesChats> MessagesChats{ get; set; }
        public DbSet<Models.CommunitiesChats> CommunitiesChats { get; set; }
        public DbSet<Models.Call> Calls { get; set; }
        public DbSet<Models.UsersCalls> UsersCalls { get; set; }
        public DbSet<Models.CommunitiesUsers> CommunitiesUsers { get; set; }
        public DbSet<Models.Friends> Friends { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.UserSender)
                .WithMany() 
                .HasForeignKey(f => f.UserSenderId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.UserReceiver)
                .WithMany() 
                .HasForeignKey(f => f.UserReceiverId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
