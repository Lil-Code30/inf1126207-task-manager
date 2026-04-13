using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
//using TaskManager.Models;

namespace TaskManager
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<Models.Priority> Priorities { get; set;  }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection_string = "";

            string database_name = "TaskManagerDB";

            optionsBuilder.UseSqlServer($"{connection_string};Database={database_name}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Priority>().HasData(
                new Models.Priority()
                {
                    PriorityId = 1, Title = "High"
                },
                new Models.Priority()
                {
                    PriorityId = 2, Title = "Medium"
                }, 
                new Models.Priority()
                {
                    PriorityId = 3, Title = "Low"
                });
        }

    }
}
