using LeagueBinding.Client.Common;
using LeagueBinding.Client.Models.Enums;

namespace LeagueBinding.Client.Models
{
    public class Quickbind
        : NotifyPropertyChanged
    {
        private QuickbindNames _quickbindName;
        public QuickbindNames QuickbindName
        {
            get { return _quickbindName; }
            set
            {
                _quickbindName = value;
                OnPropertyChanged();
            }
        }

        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                OnPropertyChanged();
            }
        }
    }
}