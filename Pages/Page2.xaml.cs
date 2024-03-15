using System.Collections.ObjectModel;

namespace HafezApp.Pages;

public partial class Page2 : ContentPage
{
	Service service;
	Beer[] cache;
	BeersViewModel beersViewModel;
	public Page2()
	{
		InitializeComponent();
		service = new Service();

		beersViewModel = new BeersViewModel();
        this.BindingContext = beersViewModel;
        this.Loaded += showData;
	}

    async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
    {

        Beer item = e.SelectedItem as Beer;
		await Navigation.PushAsync(new ModelDetails(item));
    }

    private async void showData(object sender, EventArgs e)
	{
        if (cache == null) {
            indicator.IsRunning = true;
            cache = await service.fetchBeers(5);
            indicator.IsRunning = false;
        }

		beersViewModel.Beers = new ObservableCollection<Beer>(cache);
    }

}