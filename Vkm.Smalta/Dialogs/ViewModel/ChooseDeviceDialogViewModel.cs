using System.Collections.ObjectModel;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Dialogs.Factories.Algorithms;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class ChooseDeviceDialogViewModel : DialogViewModelBase
    {
        public ChooseDeviceDialogViewModel(IDevicesFactory devicesFactory)
        {
            var actionsFactory = ServiceContainer.GetService<IActionsFactory>();

            Devices = new ObservableCollection<DeviceEntry>
                      {
                          devicesFactory.GetSmaltaDevice(new SmaltaAlgorithmsFactory(actionsFactory)),
                          devicesFactory.GetImpulseRadioLocationStation(new RlsOncAlgorithmsFactory(actionsFactory))
                      };
        }

        public ObservableCollection<DeviceEntry> Devices { get; set; }

        public DeviceEntry SelectedDeviceEntry
        {
            get { return GetProperty(() => SelectedDeviceEntry); }
            set { SetProperty(() => SelectedDeviceEntry, value); }
        }
    }
}