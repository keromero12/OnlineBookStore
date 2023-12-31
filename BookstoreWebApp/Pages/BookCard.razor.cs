using BookStore.Services;
using BookstoreWebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BookstoreWebApp.Pages;

public partial class BookCard
{
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Inject] protected DialogService DialogService { get; set; }

    [Inject] protected TooltipService TooltipService { get; set; }

    [Inject] protected ContextMenuService ContextMenuService { get; set; }

    [Inject] protected NotificationService NotificationService { get; set; }
    [Inject] protected IAuthService AuthService { get; set; }
        
    [Parameter] public Book Book { get; set; } = new();
}