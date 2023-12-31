using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookService.Models;

[Table("Book")]
public class Book
{
    [Key] public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
}

public static class BookExtensions
{
    public static BookStore.Services.Book ToProtoBook(this Book book)
    {
        return new BookStore.Services.Book
        {
            Id = book.BookId,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Price = book.Price,
            ImageUrl = book.ImageUrl
        };
    }
    
    public static Book ToBook(this BookStore.Services.Book book)
    {
        return new Book
        {
            BookId = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Price = book.Price,
            ImageUrl = book.ImageUrl
        };
    }
}

public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        public DbSet<Book> Books { get; set; }
    }