using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.InnerPages.ViewModel;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class DevicesFactory
    {
        private readonly AlgorithmsFactory algorithmsFactory;
        private readonly HistoryService historyService;

        public DevicesFactory(AlgorithmsFactory algorithmsFactory, HistoryService historyService)
        {
            this.algorithmsFactory = algorithmsFactory;
            this.historyService = historyService;
        }

        public DeviceEntry GetSmaltaDevice()
        {
            return new DeviceEntry
                   {
                       Name = Device.LO01_Smalta,
                       ReadableName = "ЛО01 Смальта",
                       Algorithms = new List<Algorithm>
                                    {
                                        algorithmsFactory.GetPrepareToLaunchAlgorithm(),
                                        algorithmsFactory.GetLaunchAlgorithm(),
                                        algorithmsFactory.GetStopAlgorithm()
                                    },
                       Pages = new List<InnerRegionPage>
                               {
                                   InnerRegionPage.LO01I_LO01K,
                                   InnerRegionPage.LO01P,
                                   InnerRegionPage.LO01R
                               },
                       FirstPageKey = InnerRegionPage.LO01P
                   };
        }

        public DeviceEntry GetImpulseRadioLocationStation()
        {
            return new DeviceEntry
                   {
                       Name = Device.RLS_ONC,
                       ReadableName = "Импульсная РЛС ОНЦ",
                       Algorithms = new List<Algorithm>()
                   };
        }
    }
}