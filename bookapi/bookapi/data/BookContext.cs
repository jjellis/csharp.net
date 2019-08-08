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
        public DbSet<Author> authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Book.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "John", LastName = "Steinbeck", BirthDate = new DateTime(1902, 2, 27) },
            new Author { Id = 2, FirstName = "Stephen", LastName = "King", BirthDate = new DateTime(1947, 9, 21) }
        );

            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Grapes of Wrath", AuthorId = 1, Category = "a" },
            new Book { Id = 2, Title = "Cannery Row", AuthorId = 1, Category = "b" },
            new Book { Id = 3, Title = "The Shining", AuthorId = 2, Category = "c" }       
        );
        }
    }
}
