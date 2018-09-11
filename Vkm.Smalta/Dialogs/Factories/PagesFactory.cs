using System;
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

        public MainInnerDevicePageViewModel CreatePage(InnerRegionPage pageKey, Algorithm algorithm)
        {
            switch (pageKey)
            {
                case InnerRegionPage.LO01P:
                    return new MainInnerDevicePageViewModel(historyService, InnerRegionPage.LO01P, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01P.png", algorithm);
                case InnerRegionPage.LO01R:
                    return new MainInnerDevicePageViewModel(historyService, InnerRegionPage.LO01R, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01R.png", algorithm);
                case InnerRegionPage.LO01I_LO01K:
                    return new MainInnerDevicePageViewModel(historyService, InnerRegionPage.LO01I_LO01K, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01I_LO01K.png", algorithm);
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageKey), pageKey, null);
            }
        }
    }
}