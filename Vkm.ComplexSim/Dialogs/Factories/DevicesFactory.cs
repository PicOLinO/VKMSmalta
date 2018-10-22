#region Usings

using System;
using System.Collections.Generic;
using Vkm.ComplexSim.Dialogs.Factories.Algorithms;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Services.Navigate;

#endregion

namespace Vkm.ComplexSim.Dialogs.Factories
{
    public class DevicesFactory : IDevicesFactory
    {
        #region IDevicesFactory

        public DeviceEntry GetImpulseRadioLocationStation(RlsOncAlgorithmsFactory algorithmsFactory)
        {
            return new DeviceEntry
                   {
                       Name = Device.RLS_ONC,
                       ReadableName = "Импульсная РЛС ОНЦ",
                       Algorithms = new List<Algorithm>
                                    {
                                        //algorithmsFactory.GetPrepareToLaunchAlgorithm(),
                                        algorithmsFactory.GetDependencyOfNoiseCoefficientByWidthOfImpulsesInPack(),
                                        //algorithmsFactory.GetDependencyOfNoiseCoefficientByWidthOfImpulsesInPackForFrontwayNoise()
                                    },
                       Pages = new List<Enum>
                               {
                                   RlsOncInnerRegionPage.Station,
                                   RlsOncInnerRegionPage.ControlPanelSimulator,
                                   RlsOncInnerRegionPage.G5_15,
                                   RlsOncInnerRegionPage.C1_65,
                                   RlsOncInnerRegionPage.Radar
                               },
                       FirstPageKey = RlsOncInnerRegionPage.Station
                   };
        }

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

        #endregion
    }
}