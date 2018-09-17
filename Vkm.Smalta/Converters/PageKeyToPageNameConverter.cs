﻿#region Usings

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
            if (value is SmaltaInnerRegionPage pageKey)
            {
                switch (pageKey)
                {
                    case SmaltaInnerRegionPage.LO01P:
                        return "ЛО01-П";
                    case SmaltaInnerRegionPage.LO01R:
                        return "ЛО01-Р";
                    case SmaltaInnerRegionPage.LO01I_LO01K:
                        return "ЛО01-И + ЛО01-К";
                    case SmaltaInnerRegionPage.Empty:
                        return null;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            throw new Exception("Unsupported type");
        }
    }
}