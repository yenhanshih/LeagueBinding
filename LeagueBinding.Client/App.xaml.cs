using System.Windows;
using LeagueBinding.Client.Views;

namespace LeagueBinding.Client
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new MainView().Show();
        }
    }
}