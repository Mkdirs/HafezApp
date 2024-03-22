namespace HafezApp.Pages;

public partial class GifPage : ContentPage
{
	public GifPage()
	{
		InitializeComponent();
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await Task.Delay(100);
        gif.IsAnimationPlaying = true;
    }
}