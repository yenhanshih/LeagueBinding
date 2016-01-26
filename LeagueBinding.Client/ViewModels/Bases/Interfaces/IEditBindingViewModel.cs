using System.Collections.Generic;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Models;

namespace LeagueBinding.Client.ViewModels.Bases.Interfaces
{
    public interface IEditBindingViewModel
    {
        bool IsEditMode { get; set; }
        bool IsAnythingChecked { get; set; }
        string PageName { get; set; }
        string SelectedPageName { get; set; }
        List<GameEvent> CastSpellGameEvents { get; }
        List<GameEvent> UseItemGameEvents { get; }
        List<Quickbind> CastSpellQuickbinds { get; }
        List<Quickbind> UseItemQuickbinds { get; }
        List<string> PageNames { get; set; }
        GameEvent SelectedGameEvent { get; set; }
        RelayCommand SelectGameEvent { get; }
        RelayCommand Edit { get; }
        RelayCommand Delete { get; }
        RelayCommand Save { get; }
        RelayCommand Cancel { get; }
    }
}