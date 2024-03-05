namespace HafezApp.Pages;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//gif");
		//TODO: Afficher page gif
    }


}

