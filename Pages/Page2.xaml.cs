using System;
using System.Collections.ObjectModel;

namespace HafezApp.Pages;

[QueryProperty(nameof(ItemToAdd), "ItemToAdd")]
public partial class Page2 : ContentPage
{
	Service service;
	Beer[] cache;
	BeersViewModel beersViewModel;
    private Beer _itemToAdd;
    public Beer ItemToAdd { get => _itemToAdd; set { _itemToAdd = value; addCustomItem(_itemToAdd); } }
	public Page2()
	{
		InitializeComponent();
		service = new Service();

		beersViewModel = new BeersViewModel();
        this.BindingContext = beersViewModel;
        this.Loaded += async (sender, args) =>
        {
            await fetchData();
            if(ItemToAdd != null)
            {
                cache = cache.Append(ItemToAdd).ToArray();
            }
            
            showData();
        };
	}

    async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
    {

        Beer item = e.SelectedItem as Beer;
		await Navigation.PushAsync(new ModelDetails(item));
    }

    private async void addCustomItem(Beer item)
    {
        if(item == null) { return; }
        cache = null;

        await fetchData();
        cache = cache.Append(item).ToArray();
        showData();
    }

    private async Task<bool> fetchData()
    {
        if (cache == null)
        {
            indicator.IsRunning = true;
            cache = await service.fetchBeers(5);
            indicator.IsRunning = false;
        }

        return true;
    }

    private void showData()
	{
        beersViewModel.Beers = new ObservableCollection<Beer>(cache);
    }

}