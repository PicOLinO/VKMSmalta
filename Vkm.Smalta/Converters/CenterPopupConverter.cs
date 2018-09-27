#region Usings

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

#endregion

namespace Vkm.Smalta.Converters
{
    public class CenterPopupConverter : MarkupExtension, IMultiValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #region IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.FirstOrDefault(v => v == DependencyProperty.UnsetValue) != null)
            {
                return double.NaN;
            }

            double placementTargetWidth = (double) values[0];
            double popupWidth = (double) values[1];
            if (popupWidth == 0)
            {
                popupWidth = 40; //TODO: hack, delete later
            }

            return (placementTargetWidth / 2.0) - (popupWidth / 2.0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}