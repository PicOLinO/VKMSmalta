using System.Collections.Generic;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Dialogs.Factories
{
    public class DevicesFactory
    {
        private readonly AlgorithmsFactory algorithmsFactory;

        public DevicesFactory(AlgorithmsFactory algorithmsFactory)
        {
            this.algorithmsFactory = algorithmsFactory;
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
                                    }
                   };
        }
    }
}