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

        public void OpenModal(IModalViewModel viewModel)
        {
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