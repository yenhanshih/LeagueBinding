using LeagueBinding.Client.Common;

namespace LeagueBinding.Client.ViewModels.Dialogs.Interface
{
    public interface IConfirmFolderDialogViewModel
        : IModalViewModel
    {
        RelayCommand Ok { get; }
    }
}