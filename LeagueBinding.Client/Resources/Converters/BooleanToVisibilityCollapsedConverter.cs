using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using LeagueBinding.Annotations;

namespace LeagueBinding.Client.Resources.Converters
{
    [MarkupExtensionReturnType(typeof(BooleanToVisibilityCollapsedConverter))]
    public class BooleanToVisibilityCollapsedConverter
        : MarkupExtension, IValueConverter
    {
        private static readonly BooleanToVisibilityCollapsedConverter Converter =
            new BooleanToVisibilityCollapsedConverter();

        [UsedImplicitly]
        public BooleanToVisibilityCollapsedConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }

            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter;
        }
    }
}