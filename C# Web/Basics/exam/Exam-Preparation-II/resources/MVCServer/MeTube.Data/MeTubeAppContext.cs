﻿using MeTubeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeTubeApp.Data
{
    public class MeTubeAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tube> Tubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerConstants.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Username)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder); 
        }
    }
}
