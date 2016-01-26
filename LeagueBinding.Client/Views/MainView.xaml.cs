using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LeagueBinding.Client.Views
{
    public partial class MainView
    {
        private TextBox _foundTextBox;

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_OnKeyUp(object sender, KeyEventArgs e)
        {
            if(_foundTextBox == null)
                _foundTextBox = FindChild<TextBox>(Application.Current.MainWindow, "PageNameTextBox");
            if (_foundTextBox != null && _foundTextBox.IsFocused) return;
            MainGrid.Focus();
        }

        private void MainView_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainGrid.Focus();
        }

        private static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null) return null;
            T foundChild = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChild<T>(child, childName);
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement == null || frameworkElement.Name != childName) continue;
                    foundChild = (T)child;
                    break;
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
