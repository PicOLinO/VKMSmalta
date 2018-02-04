using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace VKMSmalta.Converters
{
    public class ValueToStringValueConverter : BaseConverter<ValueToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intValue = (int)value;
            switch (intValue)
            {
                case 1:
                    return "Неудовлетворительно";
                case 2:
                    return "Неудовлетворительно";
                case 3:
                    return "Удовлетворительно";
                case 4:
                    return "Хорошо";
                case 5:
                    return "Отлично";
                default:
                    return null;
            }
        }
    }
}