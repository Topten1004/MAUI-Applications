using MauiSampleLogin.Services;
using MauiSampleLogin.Services.Restaurants;

namespace MauiSampleLogin;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddScoped<ILoginService, LoginService>();

        builder.Services.AddSingleton<CreateAccountViewModel>();
        builder.Services.AddSingleton<CreateAccountPage>();

        builder.Services.AddSingleton<ProductsPage>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddScoped<IRestaurantService, RestaurantService>();
        builder.Services.AddSingleton<RestaurantsViewModel>();
        builder.Services.AddSingleton<RestaurantsPage>();

        return builder.Build();
    }
}
