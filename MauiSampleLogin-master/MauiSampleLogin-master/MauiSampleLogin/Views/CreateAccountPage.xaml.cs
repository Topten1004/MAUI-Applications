namespace MauiSampleLogin.Views;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage(CreateAccountViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}