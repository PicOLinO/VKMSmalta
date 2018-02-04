using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace VKMSmalta.Converters
{
    public abstract class BaseConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }

        private static T converter;

        public abstract object Convert(object value, Type targetType, object parameter,
                                       CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter,
                                          CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}