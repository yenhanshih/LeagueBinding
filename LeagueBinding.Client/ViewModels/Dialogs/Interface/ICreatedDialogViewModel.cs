using LeagueBinding.Client.Common;

namespace LeagueBinding.Client.ViewModels.Dialogs.Interface
{
    public interface ICreatedDialogViewModel
        : IModalViewModel
    {
        RelayCommand Ok { get; }
    }
}