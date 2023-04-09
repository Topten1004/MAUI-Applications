namespace MauiLoginApp;

public partial class App : Application
{
	public static User CurrentUser;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
