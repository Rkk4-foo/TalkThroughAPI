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

            //modelBuilder.Entity<Friends>()
            //    .HasOne(f => f.UserSender)
            //    .WithMany() 
            //    .HasForeignKey(f => f.UserSenderId)
            //    .OnDelete(DeleteBehavior.Restrict); 

            //modelBuilder.Entity<Friends>()
            //    .HasOne(f => f.UserReceiver)
            //    .WithMany() 
            //    .HasForeignKey(f => f.UserReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friends>()
                .HasKey(f => new { f.UserSenderId, f.UserReceiverId, f.UserSenderUsername, f.UserReceiverUsername });

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.UserSender)
                .WithMany()
                .HasForeignKey(f => new { f.UserSenderId, f.UserSenderUsername })
                .HasPrincipalKey(us => new { us.Id, us.UserName })
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.UserReceiver)
                .WithMany()
                .HasForeignKey(f => new { f.UserReceiverId,f.UserReceiverUsername })
                .HasPrincipalKey(ur => new { ur.Id, ur.UserName})
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommunitiesUsers>()
                .HasKey(cus => new { cus.UserId, cus.UserName, cus.CommunityId });

            modelBuilder.Entity<CommunitiesUsers>()
                .HasOne(cu => cu.User)
                .WithMany()
                .HasForeignKey(cu => new { cu.UserId, cu.UserName })
                .HasPrincipalKey(u => new { u.Id, u.UserName })
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommunitiesUsers>()
                .HasOne(cu => cu.Community)
                .WithMany()
                .HasForeignKey(cu => cu.CommunityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserChat>()
                .HasKey(uc => new { uc.ChatId,uc.UserId,uc.UserName});

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.User)
                .WithMany()
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.Chat)
                .WithMany()
                .HasForeignKey(cu => cu.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
