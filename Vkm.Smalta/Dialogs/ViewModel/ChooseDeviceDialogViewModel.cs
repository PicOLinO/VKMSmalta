#region Usings

using System.Collections.ObjectModel;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Dialogs.Factories.Algorithms;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
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