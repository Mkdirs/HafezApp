namespace HafezApp.Pages;

public partial class Page2 : ContentPage
{
	Service service;
	Beer[] cache;
	public Page2()
	{
		InitializeComponent();
		service = new Service();
		

		this.Loaded += showData;
	}

	private async void showData(object sender, EventArgs e)
	{
        stack.Clear();
        if (cache == null) {
            indicator.IsRunning = true;
            cache = await service.fetchBeers(5);
            indicator.IsRunning = false;
        }


		foreach (Beer b in cache)
		{
			Label label = new Label();
			label.Text = b.name;

			stack.Add(label);
		}
    }

}