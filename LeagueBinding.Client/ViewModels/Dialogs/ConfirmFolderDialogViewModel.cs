using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.ViewModels.Dialogs
{
    public class ConfirmFolderDialogViewModel
        : BaseViewModel
        , IConfirmFolderDialogViewModel
    {
        private readonly IModalManager _modalManager;

        public ConfirmFolderDialogViewModel(IModalManager modalManager)
        {
            _modalManager = modalManager;
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