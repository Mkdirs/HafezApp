namespace HafezApp.Pages;

public partial class Page4 : ContentPage
{
	int clicks = 0;
	public Page4()
	{
		InitializeComponent();
	}

	private async void OnCookieClick(object sender, EventArgs e)
	{
		var image = sender as ImageButton;
		image.WidthRequest += 10;
		image.HeightRequest += 10;
		await Task.Delay(100);
        image.WidthRequest -= 10;
        image.HeightRequest -= 10;

		clicks++;

		label.Text = $"{clicks}";
    }
}