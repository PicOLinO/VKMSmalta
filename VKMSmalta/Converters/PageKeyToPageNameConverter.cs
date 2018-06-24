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
                    case InnerRegionPage.L001P:
                        return "Л001-П";
                    case InnerRegionPage.L001R:
                        return "Л001-Р";
                    case InnerRegionPage.L001I_L001K:
                        return "Л001-И + Л001-К";
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