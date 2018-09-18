using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.InnerPages.ViewModel;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class PagesFactory : IPagesFactory
    {
        public List<MainInnerDevicePageViewModel> CreatePagesFor(Device device, Algorithm algorithm)
        {
            switch (device)
            {
                case Device.LO01_Smalta:
                    return new List<MainInnerDevicePageViewModel>
                           {
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01I_LO01K, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01I_LO01K.png", algorithm),
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01P, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01P.png", algorithm),
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01R, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01R.png", algorithm)
                           };
                case Device.RLS_ONC:
                    return new List<MainInnerDevicePageViewModel>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(device), device, null);
            }
        }
    }
}