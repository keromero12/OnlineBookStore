using BookService.Models;
using BookStore.Services;
using Grpc.Core;
using Book = BookStore.Services.Book;

namespace BookService.Services;

public class BookService : BookStore.Services.BookService.BookServiceBase
{
    private readonly DatabaseService _databaseService;

    public BookService(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public override Task<GetBookResponse> GetBook(GetBookRequest request, ServerCallContext context)
    {
        var dbBook = _databaseService.GetBookById(request.Id);
        if (dbBook != null)
            return Task.FromResult(new GetBookResponse { Book = dbBook.ToProtoBook() });

        throw new RpcException(new Status(StatusCode.NotFound, "Kitap Bulunamadı"));
    }

    public override Task<CreateBookResponse> CreateBook(CreateBookRequest request, ServerCallContext context)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Description = request.Description,
            Price = request.Price,
            ImageUrl = request.ImageUrl
        };

        if (_databaseService.AddBook(book.ToBook()))
            return Task.FromResult(new CreateBookResponse { Book = book });

        throw new RpcException(new Status(StatusCode.NotFound, "Kitap Eklenemedi"));
    }

    public override Task<ListBooksResponse> ListBooks(ListBooksRequest request, ServerCallContext context) =>
        Task.FromResult(new ListBooksResponse
            { Books = { _databaseService.GetAllBooks().Select(b => b.ToProtoBook()) } });
}