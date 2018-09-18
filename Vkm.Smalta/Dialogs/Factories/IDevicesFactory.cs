using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IDevicesFactory
    {
        DeviceEntry GetImpulseRadioLocationStation();
        DeviceEntry GetSmaltaDevice();
    }
}