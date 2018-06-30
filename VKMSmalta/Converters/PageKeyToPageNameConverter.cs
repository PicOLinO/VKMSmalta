#region Usings

using System;
using System.Globalization;
using VKMSmalta.Services.Navigate;

#endregion

namespace VKMSmalta.Converters
{
    public class PageKeyToPageNameConverter : BaseConverter<PageKeyToPageNameConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is InnerRegionPage pageKey)
            {
                switch (pageKey)
                {
                    case InnerRegionPage.LO01P:
                        return "ЛО01-П";
                    case InnerRegionPage.LO01R:
                        return "ЛО01-Р";
                    case InnerRegionPage.LO01I_LO01K:
                        return "ЛО01-И + ЛО01-К";
                    case InnerRegionPage.Empty:
                        return null;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            throw new Exception("Unsupported type");
        }
    }
}