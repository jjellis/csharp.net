using bookapi.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bookapi.data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Book.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);       

            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Grapes of Wrath", Author = " stien beck", Category= "none" },
            new Book { Id = 2, Title = "Cannery Row", Author = "stien beck", Category= "blue" },
            new Book { Id = 3, Title = "The Shining", Author = "stephen king", Category= "boo" }
        );
        }
    }
}
