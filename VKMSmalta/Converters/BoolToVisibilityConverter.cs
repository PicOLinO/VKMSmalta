using System;
using System.Globalization;
using System.Windows;

namespace VKMSmalta.Converters
{
    public class BoolToVisibilityConverter : BaseConverter<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool) value;
            switch (boolValue)
            {
                case true:
                    return Visibility.Visible;
                case false:
                    return Visibility.Collapsed;
                default:
                    return null;
            }
        }
    }
}