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

        public JMCapstoneDbContext(DbContextOptions<JMCapstoneDbContext> options) : base(options)
        {
        }
    }
}
