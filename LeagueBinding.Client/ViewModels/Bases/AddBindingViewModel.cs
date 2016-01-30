using System.Collections.Generic;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.Models;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.ViewModels.Bases
{
    public class AddBindingViewModel
        : BaseViewModel
        , IAddBindingViewModel
    {
        private readonly IDataManager _dataManager;
        private readonly IModalManager _modalManager;

        private bool _isAnythingChecked;
        public bool IsAnythingChecked
        {
            get { return _isAnythingChecked; }
            set
            {
                _isAnythingChecked = value;
                if (!value && SelectedGameEvent != null)
                {
                    SelectedGameEvent = null;
                }
                OnPropertyChanged();
            }
        }

        private string _pageName;
        public string PageName
        {
            get { return _pageName; }
            set
            {
                _pageName = value;
                OnPropertyChanged();
            }
        }

        private List<GameEvent> _castSpellGameEvents;
        public List<GameEvent> CastSpellGameEvents
        {
            get { return _castSpellGameEvents; }
            set
            {
                _castSpellGameEvents = value;
                OnPropertyChanged();
            }
        }

        private List<Quickbind> _castSpellQuickbinds;
        public List<Quickbind> CastSpellQuickbinds
        {
            get { return _castSpellQuickbinds; }
            set
            {
                _castSpellQuickbinds = value;
                OnPropertyChanged();
            }
        }

        private List<GameEvent> _useItemGameEvents;
        public List<GameEvent> UseItemGameEvents
        {
            get { return _useItemGameEvents; }
            set
            {
                _useItemGameEvents = value;
                OnPropertyChanged();
            }
        }

        private List<Quickbind> _useItemQuickbinds;
        public List<Quickbind> UseItemQuickbinds
        {
            get { return _useItemQuickbinds; }
            set
            {
                _useItemQuickbinds = value;
                OnPropertyChanged();
            }
        }

        private GameEvent _selectedGameEvent;
        public GameEvent SelectedGameEvent
        {
            get { return _selectedGameEvent; }
            set
            {
                _selectedGameEvent = value;
                OnPropertyChanged();
            }
        }

        public AddBindingViewModel(IDataManager dataManager, IModalManager modalManager)
        {
            _dataManager = dataManager;
            _modalManager = modalManager;

            CastSpellGameEvents = _dataManager.CreateCastSpellGameEventsResource();
            CastSpellQuickbinds = _dataManager.CreateCastSpellQuickbindsResource();

            UseItemGameEvents = _dataManager.CreateUseItemGameEventsResource();
            UseItemQuickbinds = _dataManager.CreateUseItemQuickbindsResource();
        }

        private RelayCommand _selectGameEvent;
        public RelayCommand SelectGameEvent
        {
            get
            {
                return _selectGameEvent ?? (_selectGameEvent = new RelayCommand(_ =>
                {
                    var gameEvent = _ as GameEvent;
                    if (gameEvent != null)
                    {
                        SelectedGameEvent = gameEvent;
                    }
                }));
            }
        }

        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(_ =>
                {
                    if (_dataManager.FileExistInStorage(PageName) || PageName == "Default")
                    {
                        _modalManager.OpenModal(Ioc.Container.GetInstance<IConfirmationDialogViewModel>(),
                            "Error",
                            "The page name you specified already exists, please try again with a different page name or edit the existing page.");
                    }
                    else
                    {
                        _dataManager.ExportSettings(CastSpellGameEvents, CastSpellQuickbinds, UseItemGameEvents, UseItemQuickbinds, PageName);
                        _modalManager.OpenModal(Ioc.Container.GetInstance<IConfirmationDialogViewModel>(),
                            "Info",
                            "Your settings was successfully saved.");
                        ResetDefaults();

                    }
                }, x => !string.IsNullOrEmpty(PageName)));
            }
        }

        private void ResetDefaults()
        {
            PageName = null;

            CastSpellGameEvents = _dataManager.CreateCastSpellGameEventsResource();
            CastSpellQuickbinds = _dataManager.CreateCastSpellQuickbindsResource();

            UseItemGameEvents = _dataManager.CreateUseItemGameEventsResource();
            UseItemQuickbinds = _dataManager.CreateUseItemQuickbindsResource();
        }
    }
}