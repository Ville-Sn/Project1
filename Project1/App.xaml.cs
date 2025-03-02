using Project1.mvvm.viewmodels;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            MainViewModel = new RollsViewModel();
            MainViewModel.RefreshRolls();
        }

        public static RollsViewModel MainViewModel { get; set; }
    }
}
