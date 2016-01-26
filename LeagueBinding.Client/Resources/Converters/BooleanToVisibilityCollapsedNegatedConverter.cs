using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using LeagueBinding.Annotations;

namespace LeagueBinding.Client.Resources.Converters
{
    [MarkupExtensionReturnType(typeof(BooleanToVisibilityCollapsedNegatedConverter))]
    public class BooleanToVisibilityCollapsedNegatedConverter
        : MarkupExtension, IValueConverter
    {
        private static readonly BooleanToVisibilityCollapsedNegatedConverter Converter =
            new BooleanToVisibilityCollapsedNegatedConverter();

        [UsedImplicitly]
        public BooleanToVisibilityCollapsedNegatedConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Visible;
            }

            return (value is bool && (bool)value) ? Visibility.Collapsed : Visibility.Visible;
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