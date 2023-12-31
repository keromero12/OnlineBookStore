using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Services;

public class DatabaseService
{
    private readonly BookContext _ctx;

    public DatabaseService()
    {
        var options = new DbContextOptions<BookContext>();
        _ctx = new BookContext(options);
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        _ctx.Database.EnsureCreated();
        AddMockBooks();
    }

    private void AddMockBooks()
    {
        AddBook(new Book
        {
            Title = "Anna Karenina",
            Author = "Leo Tolstoy",
            Description = "Suç ve Ceza Dostoyevski'nin bütün dünyada en çok okunan başyapıtıdır.",
            Price = 77.75,
            ImageUrl = "https://m.media-amazon.com/images/I/61A25xcyciL._SY466_.jpg"
        });

        AddBook(new Book
        {
            Title = "İnsanlığımı Yitirirken",
            Author = "Osamu Dazai",
            Description = "Bir itiraf niteliğindeki üç bölümden oluşan hatıratında alkolizmle, geyşalarla, sonuçsuz kalan intiharlarla dolu, \"utanç\" yüklü yaşamının günahını çıkarır.",
            Price = 63.00,
            ImageUrl = "https://m.media-amazon.com/images/I/61m8F3-+CrL._SY466_.jpg"
        });
    }

    public bool AddBook(Book? book)
    {
        if (book == null)
            return false;
        _ctx.Books.Add(book);
        _ctx.SaveChanges(); 
        return true;
    }

    public bool UpdateBook(Book? book)
    {
        if (book == null)
            return false;
        if (GetBookById(book.BookId) == null)
            return false;
        _ctx.Books.Update(book);
        _ctx.SaveChanges();
        return true;
    }

    public bool DeleteBook(Book? book)
    {
        if (book == null)
            return false;
        if (GetBookById(book.BookId) == null)
            return false;
        _ctx.Books.Remove(book);
        _ctx.SaveChanges();
        return true;
    }

    public List<Book> GetAllBooks() => _ctx.Books.ToList();
    public Book? GetBookById(int id) => _ctx.Books.FirstOrDefault(u => u.BookId == id);
    public Book? GetBookByName(string? name) => _ctx.Books.FirstOrDefault(u => u.Title == name);
    public Book? GetBookByAuthor(string? author) => _ctx.Books.FirstOrDefault(u => u.Author == author);
}