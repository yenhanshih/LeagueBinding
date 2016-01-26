using System.IO;
using System.Windows.Forms;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.Properties;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.ViewModels.Bases
{
    public class SettingsViewModel
        : BaseViewModel
        , ISettingsViewModel
    {
        private readonly IModalManager _modalManager;

        public string InstallationPath
        {
            get { return Settings.Default.InstallationPath; }
            private set
            {
                Settings.Default.InstallationPath = value;
                Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        public SettingsViewModel(IModalManager modalManager)
        {
            _modalManager = modalManager;
        }
        
        private RelayCommand _browseFolder;
        public RelayCommand BrowseFolder
        {
            get
            {
                return _browseFolder ?? (_browseFolder = new RelayCommand(_ =>
                {
                    var dialog = new FolderBrowserDialog();
                    if (dialog.ShowDialog() != DialogResult.OK) return;
                    InstallationPath = dialog.SelectedPath;

                    if (!File.Exists(dialog.SelectedPath + "\\lol.launcher.admin.exe") 
                        && !File.Exists(dialog.SelectedPath + "\\lol.launcher.exe"))
                    {
                        _modalManager.OpenModal(Ioc.Container.GetInstance<IConfirmFolderDialogViewModel>());
                    }
                }));
            }
        }
    }
}