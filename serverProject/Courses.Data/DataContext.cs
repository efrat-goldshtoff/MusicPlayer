using System.Diagnostics;
using Courses.Core.models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Song> courses { get; set; }
        public DbSet<User> students { get; set; }
        public DbSet<Singer> guiders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=my_db");
            optionsBuilder.LogTo(msg => Console.WriteLine(msg));
        }
    }
}
