#region Usings

using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Images;
using Vkm.Smalta.View.InnerPages.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public class PagesFactory : IPagesFactory
    {
        private readonly IImagesRepository imagesRepository;


        public PagesFactory(IImagesRepository imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        #region IPagesFactory

        public List<MainInnerDevicePageViewModel> CreatePagesFor(Device device, Algorithm algorithm)
        {
            switch (device)
            {
                case Device.LO01_Smalta:
                    return new List<MainInnerDevicePageViewModel>
                           {
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01I_LO01K, imagesRepository.LO01I_LO01K, algorithm),
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01P, imagesRepository.LO01P, algorithm),
                               new SmaltaInnerDevicePageViewModel(SmaltaInnerRegionPage.LO01R, imagesRepository.LO01R, algorithm)
                           };
                case Device.RLS_ONC:
                    return new List<MainInnerDevicePageViewModel>
                           {
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.Station, imagesRepository.rls_onc_station, algorithm),
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.ControlPanelSimulator, imagesRepository.rls_onc_controlpanelsim, algorithm),
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.G5_15, imagesRepository.rls_onc_g5_15, algorithm),
                               new RlsOncInnerDevicePageViewModel(RlsOncInnerRegionPage.C1_65, imagesRepository.rls_onc_c1_65, algorithm)
                           };
                default:
                    throw new ArgumentOutOfRangeException(nameof(device), device, null);
            }
        }

        #endregion
    }
}