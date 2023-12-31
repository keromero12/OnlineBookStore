using System.Collections.Concurrent;
using BookStore.Services;
using BookstoreWebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BookstoreWebApp.Pages;

public partial class Index
{
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    [Inject] protected NavigationManager NavigationManager { get; set; }
    [Inject] protected IBookService BookService { get; set; }

    [Inject] protected DialogService DialogService { get; set; }

    [Inject] protected TooltipService TooltipService { get; set; }

    [Inject] protected ContextMenuService ContextMenuService { get; set; }

    [Inject] protected NotificationService NotificationService { get; set; }
    
    private ConcurrentBag<Book> _books = new();

    protected override async Task OnInitializedAsync()
    {
        _books = await BookService.GetAllBooks();
    }
}
    
