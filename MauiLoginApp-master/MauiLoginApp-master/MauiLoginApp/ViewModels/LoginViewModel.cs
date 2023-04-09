namespace MauiLoginApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _userName;
    [ObservableProperty]
    private string _password;

    readonly ILoginRepository<User> loginRepository = new LoginService();

    [ICommand]
    public async void Login()
    {
        if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
        {
            User user = await loginRepository.Login(UserName, Password);

            if (Preferences.ContainsKey(nameof(App.CurrentUser)))
                Preferences.Remove(nameof(App.CurrentUser));

            string userDetails = JsonConvert.SerializeObject(user);
            Preferences.Set(nameof(App.CurrentUser), userDetails);
            App.CurrentUser = user;

            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        await Shell.Current.DisplayAlert("Пустые поля", "Пожалуйста введите логин и пароль", "Ок");
    }
}
