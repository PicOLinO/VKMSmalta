using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.InnerPages.ViewModel;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class PagesFactory
    {
        private readonly HistoryService historyService;

        public PagesFactory(HistoryService historyService)
        {
            this.historyService = historyService;
        }

        public List<MainInnerDevicePageViewModel> CreatePagesFor(Device device, Algorithm algorithm)
        {
            switch (device)
            {
                case Device.LO01_Smalta:
                    return new List<MainInnerDevicePageViewModel>
                           {
                               new MainInnerDevicePageViewModel(historyService, SmaltaInnerRegionPage.LO01P, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01P.png", algorithm),
                               new MainInnerDevicePageViewModel(historyService, SmaltaInnerRegionPage.LO01R, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01R.png", algorithm),
                               new MainInnerDevicePageViewModel(historyService, SmaltaInnerRegionPage.LO01I_LO01K, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01I_LO01K.png", algorithm)
                           };
                default:
                    throw new ArgumentOutOfRangeException(nameof(device), device, null);
            }
        }

        public MainInnerDevicePageViewModel CreatePage(Enum pageKey, Algorithm algorithm)
        {
            switch (pageKey)
            {
                case SmaltaInnerRegionPage.LO01P:
                    return new MainInnerDevicePageViewModel(historyService, SmaltaInnerRegionPage.LO01P, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01P.png", algorithm);
                case SmaltaInnerRegionPage.LO01R:
                    return new MainInnerDevicePageViewModel(historyService, SmaltaInnerRegionPage.LO01R, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01R.png", algorithm);
                case SmaltaInnerRegionPage.LO01I_LO01K:
                    return new MainInnerDevicePageViewModel(historyService, SmaltaInnerRegionPage.LO01I_LO01K, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01I_LO01K.png", algorithm);
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageKey), pageKey, null);
            }
        }
    }
}