using Project1.mvvm.viewmodels;
using Project1.mvvm.models;

namespace Project1.mvvm.views;

public partial class DetailsAndResetView : ContentPage
{
	public DetailsAndResetView()
	{
		InitializeComponent();

        BindingContext = new DetailsAndResetViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //resets json file to default values
        await RollRepository.ResetRolls();

        //refreshes the rolls
        await App.MainViewModel.RefreshRolls();

        await Navigation.PopAsync();
    }
}