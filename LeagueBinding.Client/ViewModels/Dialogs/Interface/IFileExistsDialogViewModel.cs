using LeagueBinding.Client.Common;

namespace LeagueBinding.Client.ViewModels.Dialogs.Interface
{
    public interface IFileExistsDialogViewModel
        : IModalViewModel
    {
        RelayCommand Ok { get; }
    }
}