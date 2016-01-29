using System.Collections.Generic;
using System.IO;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.Properties;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.ViewModels.Bases
{
    public class SelectBindingViewModel
        : BaseViewModel
        , ISelectBindingViewModel
    {
        private readonly IDataManager _dataManager;
        private readonly IModalManager _modalManager;

        private string _selectedPageName;
        public string SelectedPageName
        {
            get { return _selectedPageName; }
            set
            {
                _selectedPageName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _pageNames;
        public List<string> PageNames
        {
            get { return _pageNames; }
            set
            {
                _pageNames = value;
                OnPropertyChanged();
            }
        }

        public SelectBindingViewModel(IDataManager dataManager, IModalManager modalManager)
        {
            _dataManager = dataManager;
            _modalManager = modalManager;

            PageNames = _dataManager.GetAllPageNames();
        }

        private RelayCommand _set;
        public RelayCommand Set
        {
            get
            {
                return _set ?? (_set = new RelayCommand(_ =>
                {
                    if (_dataManager.IsInstallationPathValid()
                        && File.Exists(Settings.Default.InstallationPath + "\\lol.launcher.admin.exe")
                        && File.Exists(Settings.Default.InstallationPath + "\\lol.launcher.exe"))
                    {
                        _dataManager.ReplaceConfigFileWithSetting(SelectedPageName);
                    }
                    else
                    {
                        _modalManager.OpenModal(Ioc.Container.GetInstance<IConfirmFolderDialogViewModel>());
                    }
                }, x => !string.IsNullOrEmpty(SelectedPageName)));
            }
        }
    }
}
