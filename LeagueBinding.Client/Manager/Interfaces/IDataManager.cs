using System.Collections.Generic;
using LeagueBinding.Client.Models;

namespace LeagueBinding.Client.Manager.Interfaces
{
    public interface IDataManager
    {
        bool FileExistInStorage(string file);
        bool IsInstallationPathValid();

        IList<string> GetAllPageNames();
        IList<GameEvent> CreateCastSpellGameEventsResource();
        IList<Quickbind> CreateCastSpellQuickbindsResource();
        IList<GameEvent> CreateUseItemGameEventsResource();
        IList<Quickbind> CreateUseItemQuickbindsResource();
        IList<GameEvent> ImportGameEventSettings(string pageName);
        IList<Quickbind> ImportQuickbindSettings(string pageName);

        void ExportSettings(IList<GameEvent> castSpellGameEvents, IList<Quickbind> quickbinds, IList<GameEvent> useItemGameEvents, IList<Quickbind> useItemQuickbinds, string pageName);
        void ReplaceConfigFileWithSetting(string pageName);
        void DeletePage(string pageName);
    }
}