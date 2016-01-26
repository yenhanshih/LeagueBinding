using LeagueBinding.Client.Common;

namespace LeagueBinding.Client.ViewModels.Bases.Interfaces
{
    public interface ISettingsViewModel
    {
        string InstallationPath { get; }
        RelayCommand BrowseFolder { get; }
    }
}