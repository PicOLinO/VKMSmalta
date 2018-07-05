#region Usings

using System;
using System.Globalization;

#endregion

namespace Vkm.Smalta.Converters
{
    public class ValueToStringValueConverter : BaseConverter<ValueToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intValue = (int) value;
            switch (intValue)
            {
                case 1:
                    return "Неудовлетворительно (1)";
                case 2:
                    return "Неудовлетворительно (2)";
                case 3:
                    return "Удовлетворительно (3)";
                case 4:
                    return "Хорошо (4)";
                case 5:
                    return "Отлично (5)";
                default:
                    return null;
            }
        }
    }
}