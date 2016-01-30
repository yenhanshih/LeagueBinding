using System.Windows;
using System.Windows.Controls;

namespace LeagueBinding.Client.Controls
{
    public class ModalDialog : ContentControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof (string),
            typeof (ModalDialog), new PropertyMetadata(string.Empty));

        public string Title
        {
            get { return GetValue(TitleProperty) as string; }
            set { SetValue(TitleProperty, value); }
        }
    }
}