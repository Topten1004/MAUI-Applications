namespace MauiSampleLogin.Views;

public partial class RestaurantsPage : ContentPage
{
    private RestaurantsViewModel _viewModel => BindingContext as RestaurantsViewModel;
    public RestaurantsPage(RestaurantsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        await _viewModel?.InitAsync();
        base.OnAppearing();
    }
}