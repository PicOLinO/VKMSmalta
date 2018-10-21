#region Usings

using Vkm.ComplexSim.Dialogs.Factories.Algorithms;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Dialogs.Factories
{
    public interface IDevicesFactory
    {
        DeviceEntry GetImpulseRadioLocationStation(RlsOncAlgorithmsFactory algorithmsFactory);
        DeviceEntry GetSmaltaDevice(SmaltaAlgorithmsFactory algorithmsFactory);
    }
}