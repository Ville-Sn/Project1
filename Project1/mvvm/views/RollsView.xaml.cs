using System.Threading.Tasks;
using Project1.mvvm.viewmodels;

namespace Project1.mvvm.views;

public partial class RollsView : ContentPage
{
	public RollsView()
	{
		InitializeComponent();
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new DetailedRollView());
    }

    private void DeleteItemClicked(object sender, EventArgs e)
    {
        MenuItem menuItem = (MenuItem)sender;
        DetailedRollViewModel roll = (DetailedRollViewModel)menuItem.BindingContext;
        App.MainViewModel.DeleteRoll(roll);
    }

    private async void NewEntryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRollView());
    }

    private async void SaveClicked(object sender, EventArgs e)
    {
        await App.MainViewModel.SaveRolls();
    }

    private async void DetailsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetailsAndResetView());
    }
}