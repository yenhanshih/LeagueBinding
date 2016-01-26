using System.Collections.Generic;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Models;

namespace LeagueBinding.Client.ViewModels.Bases.Interfaces
{
    public interface IAddBindingViewModel
    {
        bool IsAnythingChecked { get; set; }
        string PageName { get; set; }
        List<GameEvent> CastSpellGameEvents { get; }
        List<GameEvent> UseItemGameEvents { get; }
        List<Quickbind> CastSpellQuickbinds { get; }
        List<Quickbind> UseItemQuickbinds { get; }
        GameEvent SelectedGameEvent { get; set; }
        RelayCommand SelectGameEvent { get; }
        RelayCommand Save { get; }
    }
}