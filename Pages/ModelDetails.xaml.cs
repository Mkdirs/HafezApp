namespace HafezApp.Pages;

public partial class ModelDetails : ContentPage
{
	public ModelDetails(Beer item)
	{
		InitializeComponent();
		this.BindingContext = item;
	}
}