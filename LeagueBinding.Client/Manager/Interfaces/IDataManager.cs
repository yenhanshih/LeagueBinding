using System.Collections.Generic;
using LeagueBinding.Client.Models;

namespace LeagueBinding.Client.Manager.Interfaces
{
    public interface IDataManager
    {
        bool FileExistInStorage(string file);

        List<string> GetAllPageNames();
        List<GameEvent> CreateCastSpellGameEventsResource();
        List<Quickbind> CreateCastSpellQuickbindsResource();
        List<GameEvent> CreateUseItemGameEventsResource();
        List<Quickbind> CreateUseItemQuickbindsResource();
        List<GameEvent> ImportGameEventSettings(string pageName);
        List<Quickbind> ImportQuickbindSettings(string pageName);

        void ExportSettings(List<GameEvent> castSpellGameEvents, List<Quickbind> quickbinds, List<GameEvent> useItemGameEvents, List<Quickbind> useItemQuickbinds, string pageName);
        void ReplaceConfigFileWithSetting(string pageName);
        void DeletePageName(string pageName);
    }
}