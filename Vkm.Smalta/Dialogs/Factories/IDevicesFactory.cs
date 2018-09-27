#region Usings

using Vkm.Smalta.Dialogs.Factories.Algorithms;
using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IDevicesFactory
    {
        DeviceEntry GetImpulseRadioLocationStation(RlsOncAlgorithmsFactory algorithmsFactory);
        DeviceEntry GetSmaltaDevice(SmaltaAlgorithmsFactory algorithmsFactory);
    }
}