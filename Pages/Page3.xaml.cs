namespace HafezApp.Pages;

public partial class Page3 : ContentPage
{
	BeerAddViewModel viewModel;

    public Page3()
	{
		InitializeComponent();
		viewModel = new BeerAddViewModel();

		BindingContext = viewModel;
	}

	private async void accept(object sender, EventArgs e)
	{
		Beer beer = new Beer();
		beer.name = viewModel.Name;
		beer.price = viewModel.Price;
		beer.rating = new Rating();
		beer.rating.average = viewModel.Note;
		beer.rating.reviews = 1;
		beer.image = viewModel.Source;
		Dictionary<String, object> parameters = new Dictionary<string, object> { {"ItemToAdd", beer } }; 
		await Shell.Current.GoToAsync("//page2", parameters);
	}

	private async void choose_image(object sender, EventArgs e)
	{
		var result = await MediaPicker.Default.PickPhotoAsync();
		if(result != null)
		{
			viewModel.Source = result.FullPath;
        }
		
	}
}