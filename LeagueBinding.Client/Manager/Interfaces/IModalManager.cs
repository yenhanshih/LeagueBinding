using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.Manager.Interfaces
{
    public interface IModalManager
    {
        IModalViewModel CurrentModal { get; }
        bool IsModalOpen { get; }
        void OpenModal(IModalViewModel viewModel);
        void OpenModal(IConfirmationDialogViewModel viewModel, string title, string body);
        void CloseModal();
    }
}