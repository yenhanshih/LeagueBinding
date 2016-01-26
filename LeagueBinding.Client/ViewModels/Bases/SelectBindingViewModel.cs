using System.Collections.Generic;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;

namespace LeagueBinding.Client.ViewModels.Bases
{
    public class SelectBindingViewModel
        : BaseViewModel
        , ISelectBindingViewModel
    {
        private readonly IDataManager _dataManager;

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

        public SelectBindingViewModel(IDataManager dataManager)
        {
            _dataManager = dataManager;

            PageNames = _dataManager.GetAllPageNames();
        }

        private RelayCommand _set;
        public RelayCommand Set
        {
            get
            {
                return _set ?? (_set = new RelayCommand(_ =>
                {
                    _dataManager.ReplaceConfigFileWithSetting(SelectedPageName);
                }, x => !string.IsNullOrEmpty(SelectedPageName)));
            }
        }
    }
}
