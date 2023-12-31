using System.Collections.Concurrent;
using BookStore.Services;

namespace BookstoreWebApp.Services;

// BookService client kullanımı için gerekli olan interface implementasyonu
public class BookService : IBookService
{
    private readonly BookStore.Services.BookService.BookServiceClient
        _client; // gRPC client nesnesi kitap servisine bağlanmak için kullanılacak

    public BookService(IServiceManager serviceManager)
    {
        // kitap servisine bağlanmak için gerekli olan client nesnesi oluşturuluyor
        _client = serviceManager.CreateGrpcClient<BookStore.Services.BookService.BookServiceClient>("localhost", 30082);
    }

    // kitap servisine kitap ekleme metodu
    public async Task AddBook(Book book)
    {
        // kitap servisine kitap ekleme isteği gönderiliyor
        await _client.CreateBookAsync(new CreateBookRequest
        {
            Author = book.Author,
            Title = book.Title,
        });
    }

    // kitap servisinden kitap silme metodu
    public async Task RemoveBook(int id)
    {
    }

    // kitap servisinden kitap güncelleme metodu
    public async Task<Book> GetBook(int id)
    {
        // kitap servisinden kitap bilgisi getirme isteği gönderiliyor
        var response = await _client.GetBookAsync(new GetBookRequest
        {
            Id = id // kitap id'si istek içerisinde belirtiliyor
        });

        // kitap servisinden gelen cevap içerisindeki kitap bilgisi geri döndürülüyor
        return response.Book;
    }

    // kitap servisinden tüm kitapları getirme metodu
    public async Task<ConcurrentBag<Book>> GetAllBooks()
    {
        // kitap servisinden tüm kitapları getirme isteği gönderiliyor
        var books = new ConcurrentBag<Book>();
        var response = await _client.ListBooksAsync(new ListBooksRequest());
        response.Books.ToList().ForEach(x => books.Add(x));
        // kitap servisinden gelen cevap içerisindeki kitap bilgileri geri döndürülüyor
        return books;
    }
}