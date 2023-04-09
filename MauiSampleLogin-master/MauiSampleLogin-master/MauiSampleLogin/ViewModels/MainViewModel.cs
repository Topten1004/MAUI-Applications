using CommunityToolkit.Maui.Alerts;
using MauiSampleLogin.Contracts.Login;
using MauiSampleLogin.Services;

namespace MauiSampleLogin.ViewModels;

[ObservableObject]
public partial class MainViewModel
{
    private readonly ILoginService _loginService;
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    public MainViewModel(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [RelayCommand]
    public async Task Login()
    {
        if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Unknown ||
            Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.None)
        {
            await Toast.Make("Sem conexão com a internet", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            return;
        }

        var loginRequest = new Models.LoginRequest
        {
            Email = email,
            Password = password
        };

        var validator = new LoginContract(loginRequest);
        if (!validator.IsValid)
        {
            await Toast.Make("Dados são inválidos", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            return;
        }

        var result = await _loginService.LoginAsync(loginRequest);

        if (string.IsNullOrEmpty(result.Access_Token))
        {
            await Toast.Make("A requisação falhou, tente novamente.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            return;
        }

        await SecureStorage.SetAsync("token", result.Access_Token);
        await SecureStorage.SetAsync("refreshToken", result.Refresh_Token);

        await Shell.Current.GoToAsync($"//{nameof(RestaurantsPage)}");

    }

    [RelayCommand]
    public async Task CreateAccount()
    {
        await Shell.Current.GoToAsync(nameof(CreateAccountPage));
    }
}
