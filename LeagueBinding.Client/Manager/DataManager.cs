using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using LeagueBinding.Client.Manager.Interfaces;
using LeagueBinding.Client.Models;
using LeagueBinding.Client.Models.Enums;
using LeagueBinding.Client.Properties;

namespace LeagueBinding.Client.Manager
{
    public class DataManager 
        : IDataManager
    {
        public bool FileExistInStorage(string file)
        {
            return File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\" + file);
        }

        public bool IsInstallationPathValid()
        {
            return !string.IsNullOrEmpty(Settings.Default.InstallationPath) && File.Exists(Settings.Default.InstallationPath + "\\lol.launcher.exe");
        }

        public List<string> GetAllPageNames()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages");
            var list = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\").Select(Path.GetFileName).ToList();
            list.Insert(0, "Default");
            return list;
        }

        public List<GameEvent> CreateCastSpellGameEventsResource()
        {
            return new List<GameEvent>
                {
                    new GameEvent {GameEventName = GameEventNames.evtCastSpell1, GameEventValue = "q"},
                    new GameEvent {GameEventName = GameEventNames.evtCastSpell2, GameEventValue = "w"},
                    new GameEvent {GameEventName = GameEventNames.evtCastSpell3, GameEventValue = "e"},
                    new GameEvent {GameEventName = GameEventNames.evtCastSpell4, GameEventValue = "r"}
                };
        }

        public List<Quickbind> CreateCastSpellQuickbindsResource()
        {
            return new List<Quickbind>
                {
                    new Quickbind {QuickbindName = QuickbindNames.evtCastSpell1smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtCastSpell2smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtCastSpell3smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtCastSpell4smart}
                };
        }

        public List<GameEvent> CreateUseItemGameEventsResource()
        {
            return new List<GameEvent>
                {
                    new GameEvent {GameEventName = GameEventNames.evtUseItem1, GameEventValue = "1"},
                    new GameEvent {GameEventName = GameEventNames.evtUseItem2, GameEventValue = "2"},
                    new GameEvent {GameEventName = GameEventNames.evtUseItem3, GameEventValue = "3"},
                    new GameEvent {GameEventName = GameEventNames.evtUseItem4, GameEventValue = "4"},
                    new GameEvent {GameEventName = GameEventNames.evtUseItem5, GameEventValue = "5"},
                    new GameEvent {GameEventName = GameEventNames.evtUseItem6, GameEventValue = "6"},
                };
        }

        public List<Quickbind> CreateUseItemQuickbindsResource()
        {
            return new List<Quickbind>
                {
                    new Quickbind {QuickbindName = QuickbindNames.evtUseItem1smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtUseItem2smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtUseItem3smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtUseItem4smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtUseItem5smart},
                    new Quickbind {QuickbindName = QuickbindNames.evtUseItem6smart}
                };
        }

        public List<Quickbind> ImportQuickbindSettings(string pageName)
        {
            var quickbinds = new List<Quickbind>();
            var pathInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\");
            if (pathInfo.Directory == null) return null;
            var file = new StreamReader(pathInfo.DirectoryName + "\\" + pageName);
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                if (line == "[Quickbinds]") break;
            }
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                if (line == null) continue;
                var arr = line.Split('=');
                if (arr.Length == 1) break;
                quickbinds.Add(new Quickbind
                {
                    QuickbindName = (QuickbindNames)Enum.Parse(typeof(QuickbindNames), arr[0]),
                    Enabled = arr[1] == "1"
                });
            }
            file.Close();
            return quickbinds;
        }

        public List<GameEvent> ImportGameEventSettings(string pageName)
        {
            var gameEvents = new List<GameEvent>();
            var pathInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\");
            if (pathInfo.Directory == null) return null;
            var file = new StreamReader(pathInfo.DirectoryName + "\\" + pageName);
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                if (line == "[GameEvents]") break;
            }
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                if (line == null) continue;
                var arr = line.Split('=');
                if (arr.Length == 1) break;
                if (arr[1].Contains("Shift"))
                {
                    arr[1] = arr[1].Remove(0, 7).Trim('[').Trim(']').ToUpper();
                }
                else
                {
                    arr[1] = arr[1].Trim('[').Trim(']');
                }
                gameEvents.Add(new GameEvent
                {
                    GameEventName = (GameEventNames)Enum.Parse(typeof(GameEventNames), arr[0]),
                    GameEventValue = arr[1]
                });
            }
            file.Close();
            return gameEvents;
        }

        public void ExportSettings(List<GameEvent> castSpellGameEvents, List<Quickbind> castSpellQuickbinds, List<GameEvent> useItemGameEvents, List<Quickbind> useItemQuickbinds, string pageName)
        {
            var pathInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\");
            if (pathInfo.Directory != null && !pathInfo.Directory.Exists && pathInfo.DirectoryName != null)
            {
                Directory.CreateDirectory(pathInfo.DirectoryName);
            }
            if (pathInfo.Directory == null) return;

            var file = new StreamWriter(string.Format(pathInfo.FullName + "\\" + pageName));

            file.WriteLine("[Quickbinds]");
            foreach (var castSpellQuickbind in castSpellQuickbinds)
            {
                file.WriteLine(castSpellQuickbind.QuickbindName + "=" + (castSpellQuickbind.Enabled ? '1' : '0'));
            }
            foreach (var useItemQuickbind in useItemQuickbinds)
            {
                file.WriteLine(useItemQuickbind.QuickbindName + "=" + (useItemQuickbind.Enabled ? '1' : '0'));
            }
            file.WriteLine();

            file.WriteLine("[GameEvents]");
            foreach (var castSpellGameEvent in castSpellGameEvents)
            {
                file.WriteLine(castSpellGameEvent.GameEventName + "=" + castSpellGameEvent.ExportValue());
            }
            foreach (var useItemGameEvent in useItemGameEvents)
            {
                file.WriteLine(useItemGameEvent.GameEventName + "=" + useItemGameEvent.ExportValue());
            }
            file.Close();
        }

        public void ReplaceConfigFileWithSetting(string pageName)
        {
            if (pageName == "Default")
            {
                File.Delete(Settings.Default.InstallationPath + "\\Config\\input.ini");
            }
            else
            {
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\" + pageName,
                    Settings.Default.InstallationPath + "\\Config\\input.ini", true);
            }
        }

        public void DeletePageName(string pageName)
        {
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LeagueBinding\\Pages\\" + pageName);
        }
    }
}