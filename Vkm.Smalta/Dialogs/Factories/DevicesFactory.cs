using System.Collections.Generic;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class DevicesFactory
    {
        public DeviceEntry GetSmaltaDevice(AlgorithmsFactory algorithmsFactory)
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
                                    }
                   };
        }
    }
}