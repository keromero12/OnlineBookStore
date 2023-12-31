using Auth.Services;
using BookstoreWebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace BookstoreWebApp.Pages
{
    public partial class Login
    {
        [Inject] protected IJSRuntime JSRuntime { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }

        [Inject] protected DialogService DialogService { get; set; }

        [Inject] protected TooltipService TooltipService { get; set; }

        [Inject] protected ContextMenuService ContextMenuService { get; set; }

        [Inject] protected NotificationService NotificationService { get; set; }
        [Inject] protected IAuthService AuthService { get; set; }

        private LoginRequest _loginRequest;
        private RegisterRequest _registerRequest;
        private bool _showErrors;
        private string? _error;

        private async Task HandleLogin(LoginArgs args)
        {
            _showErrors = false;
            _loginRequest = new LoginRequest
            {
                Email = args.Username,
                Password = args.Password,
                Remember = args.RememberMe
            };
            var result = await AuthService.Login(_loginRequest);

            if (result.Successful)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                _error = result.Error;
                _showErrors = true;
            }
        }

        private void HandleRegister(string registerWithDefaultValues)
        {
            NavigationManager.NavigateTo("/register");
        }
    }
}