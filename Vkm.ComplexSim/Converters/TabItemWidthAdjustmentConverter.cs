using System;
using System.Windows.Data;
using static System.Int32;

namespace Vkm.ComplexSim.Converters
{
    public class TabItemWidthAdjustmentConverter : BaseConverter<TabItemWidthAdjustmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var lTabControlWidth = value as double? ?? 50;
            var lTabsCount = (parameter is string s) ? Parse(s) : 1;
            return lTabControlWidth / lTabsCount - 3;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}