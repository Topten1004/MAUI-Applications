namespace MauiLoginApp.UserControl;

public partial class FlyoutHeaderControl : ContentPage
{
	public FlyoutHeaderControl()
	{

		InitializeComponent();

		if (App.CurrentUser != null)
		{
			lblUserName.Text = $"Вы вошли как: Admin";
            lblUserRole.Text = "admin@admin.kg";
		}
		else
		{
            lblUserName.Text = $"Вы вошли как: Канат";
            lblUserRole.Text = "Admin";
        }
	}
}