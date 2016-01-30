using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.ViewModels.Dialogs
{
    public class ConfirmationDialogViewModel
        : BaseViewModel
        , IConfirmationDialogViewModel
    {
        private readonly IModalManager _modalManager;

        public ConfirmationDialogViewModel(IModalManager modalManager)
        {
            _modalManager = modalManager;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set
            {
                _body = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _ok;
        public RelayCommand Ok
        {
            get
            {
                return _ok ?? (_ok = new RelayCommand(_ =>
                {
                    _modalManager.CloseModal();
                }));
            }
        }
    }
}