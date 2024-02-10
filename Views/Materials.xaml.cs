namespace Organizador_Apollo.Views;
using Organizador_Apollo.ViewModels;

public partial class Materials : ContentPage
{
	public Materials()
	{
		InitializeComponent();
		BindingContext = new MaterialsViewModel();
	}
}