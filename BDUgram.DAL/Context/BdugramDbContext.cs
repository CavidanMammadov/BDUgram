using BDugram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.DAL.Context
{
    public class BdugramDbContext : DbContext
    {
        public BdugramDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<Blog> Blogs  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BdugramDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
