#region Usings

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

#endregion

namespace Vkm.Smalta.Converters
{
    public abstract class BaseConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        private static T converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }

        #region IValueConverter

        public abstract object Convert(object value, Type targetType, object parameter,
                                       CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter,
                                          CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}