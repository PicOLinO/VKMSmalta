#region Usings

using System.Windows.Controls;
using System.Windows.Navigation;
using Vkm.ComplexSim.View.InnerPages.ViewModel;
using Vkm.ComplexSim.View.ViewModel;

#endregion

namespace Vkm.ComplexSim.View
{
    /// <summary>
    /// Interaction logic for DevicePage.xaml
    /// </summary>
    public partial class DevicePage : Page
    {
        public DevicePage()
        {
            InitializeComponent();
        }

        private void Frame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Content != null)
            {
                var vm = (DevicePageViewModel)DataContext;
                vm.NavigateOnInnerPage(((MainInnerDevicePageViewModel)e.Content).PageKey);
            }
        }
    }
}