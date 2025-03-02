using Project1.mvvm.models;
using System.Threading.Tasks;

namespace Project1.mvvm.views;

public partial class NewRollView : ContentPage
{

    string entryName = string.Empty;

    public NewRollView()
	{
		InitializeComponent();

        BindingContext = new viewmodels.NewRollViewModel();
    }

    private void entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        entryName = ((Entry)sender).Text;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Traits trait = new Traits("", "", "", "", "");

        Roll newRoll = new Roll(App.MainViewModel.Rolls.Count + 1 , entryName, "", "", trait);
        App.MainViewModel.AddRoll(newRoll);
        await Navigation.PopAsync();
    }
}