using System.Collections.ObjectModel;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class ChooseDeviceDialogViewModel : DialogViewModelBase
    {
        public ChooseDeviceDialogViewModel(DevicesFactory devicesFactory, AlgorithmsFactory algorithmsFactory)
        {
            Devices = new ObservableCollection<DeviceEntry>
                      {
                          devicesFactory.GetSmaltaDevice(algorithmsFactory)
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