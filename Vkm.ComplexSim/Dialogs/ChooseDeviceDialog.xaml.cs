#region Usings

using System.Windows.Controls;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Dialogs.ViewModel;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Dialogs
{
    /// <summary>
    /// Interaction logic for ChooseDeviceDialog.xaml
    /// </summary>
    public partial class ChooseDeviceDialog : DialogBase
    {
        public ChooseDeviceDialog(IDevicesFactory devicesFactory)
        {
            InitializeComponent();
            DataContext = new ChooseDeviceDialogViewModel(devicesFactory);
            Initialize();
        }


        public DeviceEntry SelectedDevice => (DataContext as ChooseDeviceDialogViewModel)?.SelectedDeviceEntry;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Close();
        }
    }
}