﻿using System.Collections.Generic;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=my_db");
            //optionsBuilder.LogTo(msg => Console.WriteLine(msg));
        }
    }
}
