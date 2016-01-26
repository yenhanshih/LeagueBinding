using System.Collections.Generic;
using System.Linq;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.Models;
using LeagueBinding.Client.Models.Enums;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;
using LeagueBinding.Client.ViewModels.Dialogs.Interface;

namespace LeagueBinding.Client.ViewModels.Bases
{
    public class EditBindingViewModel
        : BaseViewModel
        , IEditBindingViewModel
    {
        private readonly IDataManager _dataManager;
        private readonly IModalManager _modalManager;

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                _isEditMode = value;
                OnPropertyChanged();
            }
        }

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

        public EditBindingViewModel(IDataManager dataManager, IModalManager modalManager)
        {
            _dataManager = dataManager;
            _modalManager = modalManager;

            PageNames = _dataManager.GetAllPageNames();
        }

        private RelayCommand _edit;
        public RelayCommand Edit
        {
            get
            {
                return _edit ?? (_edit = new RelayCommand(_ =>
                {
                    if (SelectedPageName == "Default")
                    {
                        // TODO: Default behavior
                    }
                    else
                    {
                        // TODO: Initialize default values
                        var quickBindSettings = _dataManager.ImportQuickbindSettings(SelectedPageName);
                        var gameEventSettings = _dataManager.ImportGameEventSettings(SelectedPageName);
                        CastSpellGameEvents =
                            gameEventSettings.Where(x => x.GameEventName <= GameEventNames.evtCastSpell4)
                                                         .ToList();
                        UseItemGameEvents =
                            gameEventSettings.Where(x => x.GameEventName >= GameEventNames.evtUseItem1)
                                                         .ToList();
                        CastSpellQuickbinds =
                            quickBindSettings.Where(x => x.QuickbindName <= QuickbindNames.evtCastSpell4smart)
                                                         .ToList();

                        UseItemQuickbinds =
                            quickBindSettings.Where(x => x.QuickbindName >= QuickbindNames.evtUseItem1smart)
                                                         .ToList();
                        IsEditMode = true;
                    }
                }, x => !string.IsNullOrEmpty(SelectedPageName)));
            }
        }

        private RelayCommand _delete;
        public RelayCommand Delete
        {
            get
            {
                return _delete ?? (_delete = new RelayCommand(_ =>
                {
                    if (_dataManager.FileExistInStorage(SelectedPageName)) _dataManager.DeletePageName(SelectedPageName);
                    PageNames = _dataManager.GetAllPageNames();
                }, x => !string.IsNullOrEmpty(SelectedPageName)));
            }
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
                        _modalManager.OpenModal(Ioc.Container.GetInstance<IFileExistsDialogViewModel>());
                    }
                    else
                    {
                        _dataManager.ExportSettings(CastSpellGameEvents, CastSpellQuickbinds, UseItemGameEvents, UseItemQuickbinds, PageName);
                        _modalManager.OpenModal(Ioc.Container.GetInstance<ICreatedDialogViewModel>());
                    }
                }, x => !string.IsNullOrEmpty(PageName)));
            }
        }

        private RelayCommand _cancel;
        public RelayCommand Cancel
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand(_ =>
                {
                    CastSpellGameEvents = null;
                    UseItemGameEvents = null;
                    CastSpellQuickbinds = null;
                    UseItemQuickbinds = null;
                    IsEditMode = false;
                }));
            }
        }
    }
}