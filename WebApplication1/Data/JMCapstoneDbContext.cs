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

        public JMCapstoneDbContext(DbContextOptions<JMCapstoneDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoute>().HasKey(c => new { c.UserID, c.RouteID });
            modelBuilder.Entity<RequestorRequested>().HasKey(c => new { c.RequestorID, c.RequestedID });
            
        }
    }
}
