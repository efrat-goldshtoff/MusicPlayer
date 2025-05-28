using System.Collections.Generic;
using System.Diagnostics;
using serverProject.Core.models;
using Microsoft.EntityFrameworkCore;

namespace serverProject.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Song> songs { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Singer> singers { get; set; }
        public DbSet<PlayList> playLists { get; set; }
        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=my_db");
            //optionsBuilder.LogTo(msg => Console.WriteLine(msg));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Song and PlayList
            modelBuilder.Entity<PlayList>()
                .HasMany(p => p.songs)
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
