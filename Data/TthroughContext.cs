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
            
            modelBuilder.Entity<UsersCalls>()
            .HasKey(uc => new { uc.CallId, uc.UserId, uc.UserName });

            
            modelBuilder.Entity<UsersCalls>()
                .HasOne(uc => uc.Users)
                .WithMany() 
                .HasForeignKey(uc => new { uc.UserId, uc.UserName }) 
                .HasPrincipalKey(u => new { u.Id, u.UserName })
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<UsersCalls>()
                .HasOne(uc => uc.Calls)
                .WithMany() 
                .HasForeignKey(uc => uc.CallId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsersChats>()
                .HasKey(uch => new { uch.ChatId, uch.UserId, uch.UserName });

            modelBuilder.Entity<UsersChats>()
                .HasOne(uch => uch.User)
                .WithMany()
                .HasForeignKey(uch => new {uch.UserId,uch.UserName })
                .HasPrincipalKey (u => new { u.Id,u.UserName })
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UsersChats>()
                .HasOne(uch => uch.Chat)
                .WithMany()
                .HasForeignKey(uch => uch.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
