namespace Project1.mvvm.views;

public partial class DetailedRollView : ContentPage
{
	public DetailedRollView()
	{
		InitializeComponent();

        BindingContext = App.MainViewModel.SelectedRoll;
    }
}