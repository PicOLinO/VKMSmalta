using System.Collections.Generic;
using System.Linq;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.ViewModel;
using VKMSmalta.ViewModel;

namespace VKMSmalta.Services
{
    public class DependencyContainer
    {
        public bool IsDebug { get; set; }

        public const string AssemblyName = nameof(VKMSmalta);

        private MainWindowViewModel mainWindowVm;
        private DevicePageViewModel devicePageVm;
        private MainPageViewModel mainPageVm;

        public static DependencyContainer Instance { get; private set; }
        
        public static void InitializeService()
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer();
            }
        }

        public void ReSetDevicePageViewModel(DevicePageViewModel vm)
        {
            devicePageVm = vm;
        }

        public void ReSetMainPageViewModel(MainPageViewModel vm)
        {
            mainPageVm = vm;
        }

        public void ReSetMainWindowViewModel(MainWindowViewModel vm)
        {
            mainWindowVm = vm;
        }

        public IEnumerable<ElementViewModelBase> GetAllElementsOfCurrentDevicePage()
        {
            return devicePageVm.UnionedElements;
        }

        public void SetLoadingSplash(bool isLoading)
        {
            mainWindowVm.IsLoadingSplashVisible = isLoading;
        }
    }
}