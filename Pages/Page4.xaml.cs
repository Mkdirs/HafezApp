namespace HafezApp.Pages;

public partial class Page4 : ContentPage
{
	int clicks = 0;
	public Page4()
	{
		InitializeComponent();
		Task.Run(async () =>
		{
			while(true)
			{
				walk_gif.TranslationX += 2.5;
                

                if (walk_gif.TranslationX >= 150)
				{
					walk_gif.TranslationX = 0;
				}

				await Task.Delay(100);
            }
			
		});
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

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		await Task.Delay(100);
		walk_gif.IsAnimationPlaying = true;
    }
}