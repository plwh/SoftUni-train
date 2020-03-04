using KittenApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KittenApp.Data
{
    public class KittenAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Kittens { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerConnectionParameters.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
