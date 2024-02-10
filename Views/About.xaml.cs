namespace Organizador_Apollo.Views;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://github.com/Team8105/Organizador-Apollo");
    }
}