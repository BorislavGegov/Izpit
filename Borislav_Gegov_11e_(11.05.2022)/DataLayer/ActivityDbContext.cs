using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext()
        {

        }

        public ActivityDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-JDCA8S0\SQLEXPRESS;Database=ActivityDB;Trusted_Connection=True");
            }
        }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
