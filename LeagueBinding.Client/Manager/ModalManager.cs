using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.Manager
{
    public class ModalManager
        : NotifyPropertyChanged
        , IModalManager
    {
        private IModalViewModel _currentModal;
        public IModalViewModel CurrentModal
        {
            get { return _currentModal; }
            private set
            {
                _currentModal = value;
                OnPropertyChanged();
            }
        }

        private bool _isModalOpen;
        public bool IsModalOpen
        {
            get { return _isModalOpen; }
            private set
            {
                _isModalOpen = value;
                OnPropertyChanged();
            }
        }

        // For generic modal
        public void OpenModal(IModalViewModel viewModel)
        {
            CurrentModal = viewModel;
            IsModalOpen = true;
        }

        // For confirmation modal
        public void OpenModal(IConfirmationDialogViewModel viewModel, string title, string body)
        {
            viewModel.Title = title;
            viewModel.Body = body;
            CurrentModal = viewModel;
            IsModalOpen = true;
        }

        public void CloseModal()
        {
            IsModalOpen = false;
            CurrentModal = null;
        }
    }
}