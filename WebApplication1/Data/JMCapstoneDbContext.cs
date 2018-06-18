using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class JMCapstoneDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<UserRoute> UserRoutes { get; set; }
        public DbSet<RouteReview> RouteReviews { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RequestorRequested> Friendships { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        public JMCapstoneDbContext(DbContextOptions<JMCapstoneDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.FriendShips)
                .WithOne(t => t.Requestor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestorRequested>()
                .HasOne(p => p.Requestor)
                .WithMany(t => t.FriendShips )
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(p => p.FriendShips)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserRoute>().HasKey(c => new { c.UserID, c.RouteID });
            //modelBuilder.Entity<RequestorRequested>().HasKey(c => new { c.RequestorID, c.RequestedID });

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
