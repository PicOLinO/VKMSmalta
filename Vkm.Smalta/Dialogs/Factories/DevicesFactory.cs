using System;
using System.Collections.Generic;
using System.Linq;
using Vkm.Smalta.Dialogs.Factories.Algorithms;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class DevicesFactory : IDevicesFactory
    {
        public DeviceEntry GetSmaltaDevice(SmaltaAlgorithmsFactory algorithmsFactory)
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
                       Pages = new List<Enum>
                               {
                                   SmaltaInnerRegionPage.LO01I_LO01K,
                                   SmaltaInnerRegionPage.LO01P,
                                   SmaltaInnerRegionPage.LO01R
                               },
                       FirstPageKey = SmaltaInnerRegionPage.LO01P
                   };
        }

        public DeviceEntry GetImpulseRadioLocationStation(RlsOncAlgorithmsFactory algorithmsFactory)
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