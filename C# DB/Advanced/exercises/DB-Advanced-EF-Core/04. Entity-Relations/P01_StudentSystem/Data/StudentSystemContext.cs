﻿namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(){ }
        public StudentSystemContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(string.Format(Configuration.ConnectionString, "StudentSystem"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity => 
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode();

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("char(10)")
                    .IsFixedLength()
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Birthday)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode();

                entity.Property(e => e.Description)
                    .IsUnicode()
                    .IsRequired(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode();

                entity.Property(e => e.Url)
                    .IsUnicode(false);

                entity.HasOne(e => e.Course)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                    .IsUnicode(false);

                entity.HasOne(e => e.Student)
                    .WithMany(p => p.HomeworkSubmissions)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(p => p.HomeworkSubmissions)
                    .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new {e.StudentId, e.CourseId});

                entity.HasOne(e => e.Student)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(p => p.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
            });
        }
    }
}