using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using serverProject.Core.models;

namespace serverProject.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayList>()
                .HasMany(p => p.Songs)
                .WithMany(s => s.PlayLists);

            modelBuilder.Entity<PlayList>()
                .HasOne(p => p.User)
                .WithMany(u => u.PlayLists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "admin", Email = "admin@example.com", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), Role = "Admin" },
                new User { Id = 2, Name = "user1", Email = "user1@example.com", Password = BCrypt.Net.BCrypt.HashPassword("user123"), Role = "User" }
            );
        }
    }
}
