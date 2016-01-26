using System;
using System.Windows;
using System.Windows.Controls;

namespace LeagueBinding.Client.Controls
{
    public class ModalDialog : ContentControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof (String),
            typeof (ModalDialog), new PropertyMetadata(String.Empty));

        public String Title
        {
            get { return (String) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}