using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LeagueBinding.Client.ViewModels.Bases.Interfaces;

namespace LeagueBinding.Client.Views
{
    public partial class EditBindingView
    {
        public IEditBindingViewModel ViewModel
        {
            get { return DataContext as IEditBindingViewModel; }
        }

        public EditBindingView()
        {
            InitializeComponent();
        }

        private void FocusManager_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var button = e.Source as RadioButton;
            if (button != null) button.IsChecked = false;
        }

        private void EditBindingView_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (PageNameTextBox.IsFocused) return;
            if (!ViewModel.IsAnythingChecked) return;
            if (ViewModel.SelectedGameEvent == null) return;

            foreach (var castSpellGameEvent in ViewModel.CastSpellGameEvents.Where(gameEvent => gameEvent.GameEventValue == e.Text))
            {
                castSpellGameEvent.GameEventValue = "";
                break;
            }

            foreach (var useItemGameEvent in ViewModel.UseItemGameEvents.Where(gameEvent => gameEvent.GameEventValue == e.Text))
            {
                useItemGameEvent.GameEventValue = "";
                break;
            }

            ViewModel.SelectedGameEvent.GameEventValue = e.Text;
        }

        private void EditBindingView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab) return;
            e.Handled = true;
            if (ViewModel.SelectedGameEvent == null) return;
            ViewModel.SelectedGameEvent.GameEventValue = e.Key.ToString();
        }
    }
}
