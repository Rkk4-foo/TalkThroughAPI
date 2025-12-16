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
        public DbSet<Models.CommunitiesUsers> CommunitiesUsers { get; set; }
        public DbSet<Models.Friends> Friends { get; set; }

        public DbSet<Models.UserChat> UserChat { get; set; }
        public DbSet<Models.Channels> Channels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Friends>()
                .HasKey(f => new { f.UserSenderId, f.UserReceiverId });

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.UserSender)
                .WithMany()
                .HasForeignKey(f => f.UserSenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.UserReceiver)
                .WithMany()
                .HasForeignKey(f => f.UserReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommunitiesUsers>()
                .HasKey(cu => new { cu.UserId, cu.CommunityId });

            modelBuilder.Entity<CommunitiesUsers>()
                .HasOne(cu => cu.User)
                .WithMany()
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommunitiesUsers>()
                .HasOne(cu => cu.Community)
                .WithMany()
                .HasForeignKey(cu => cu.CommunityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserChat>()
                .HasKey(uc => new { uc.ChatId, uc.UserId });

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.User)
                .WithMany()
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.Chat)
                .WithMany()
                .HasForeignKey(uc => uc.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
