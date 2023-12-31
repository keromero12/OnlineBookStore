using System.Collections.Concurrent;
using BookStore.Services;

namespace BookstoreWebApp.Services;

public interface IBookService
{
    public Task AddBook(Book book);
    public Task RemoveBook(int id);
    public Task<Book> GetBook(int id);
    public Task<ConcurrentBag<Book>> GetAllBooks();
}