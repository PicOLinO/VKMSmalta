#region Usings

using System;
using System.Globalization;
using System.Windows;

#endregion

namespace Vkm.Smalta.Converters
{
    public class BoolToVisibilityConverter : BaseConverter<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringParameter = (string) parameter;
            var boolValue = (bool) value;

            if (stringParameter == "Inverse")
            {
                boolValue = !boolValue;
            }

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