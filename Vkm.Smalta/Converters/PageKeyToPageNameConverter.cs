#region Usings

using System;
using System.Globalization;
using Vkm.Smalta.Services.Navigate;

#endregion

namespace Vkm.Smalta.Converters
{
    public class PageKeyToPageNameConverter : BaseConverter<PageKeyToPageNameConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case null:
                    return null;
                case SmaltaInnerRegionPage pageKey:
                    switch (pageKey)
                    {
                        case SmaltaInnerRegionPage.LO01P:
                            return "ЛО01-П";
                        case SmaltaInnerRegionPage.LO01R:
                            return "ЛО01-Р";
                        case SmaltaInnerRegionPage.LO01I_LO01K:
                            return "ЛО01-И + ЛО01-К";
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                default:
                    throw new Exception("Unsupported type");
            }
        }
    }
}