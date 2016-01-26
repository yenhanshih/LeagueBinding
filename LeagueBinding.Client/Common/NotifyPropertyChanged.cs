using System.ComponentModel;
using System.Runtime.CompilerServices;
using LeagueBinding.Annotations;

namespace LeagueBinding.Client.Common
{
    public class NotifyPropertyChanged
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}