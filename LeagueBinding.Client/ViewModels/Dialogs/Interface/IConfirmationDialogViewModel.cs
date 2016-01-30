using LeagueBinding.Client.Common;

namespace LeagueBinding.Client.ViewModels.Dialogs.Interface
{
    public interface IConfirmationDialogViewModel
        : IModalViewModel
    {
        string Title { get; set; }
        string Body { get; set; }
        RelayCommand Ok { get; }
    }
}