using System.Collections.Generic;
using System.Diagnostics;
using serverProject.Core.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace serverProject.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration; // Add IConfiguration

        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                            ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }

        // ... OnModelCreating (keep as is, with PlayList and User configurations)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Song and PlayList
            modelBuilder.Entity<PlayList>()
                .HasMany(p => p.Songs)
                .WithMany(s => s.PlayLists);
            // Optional: Configure User-PlayList one-to-many relationship explicitly
            modelBuilder.Entity<PlayList>()
                .HasOne(p => p.User)
                .WithMany(u => u.PlayLists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade, depending on desired behavior

            // Add a unique index for username and email in User table to prevent duplicates
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

            // Seed initial data (optional but good for testing)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "admin", Email = "admin@example.com", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), Role = "Admin" },
                new User { Id = 2, Name = "user1", Email = "user1@example.com", Password = BCrypt.Net.BCrypt.HashPassword("user123"), Role = "User" }
            );
            // Add other seed data as needed (Singers, Songs)
        }

    }
}

