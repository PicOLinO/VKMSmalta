#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.ViewModel;
using VKMSmalta.ViewModel;

#endregion

namespace VKMSmalta.Services
{
    public class DependencyContainer
    {
        public const string AssemblyName = nameof(VKMSmalta);
        private readonly AppGlobal appGlobal;
        private DevicePageViewModel devicePageVm;
        private MainPageViewModel mainPageVm;

        private MainWindowViewModel mainWindowVm;

        private DependencyContainer(Config config)
        {
            Config = config;
            appGlobal = new AppGlobal();
        }

        public Config Config { get; }

        public static DependencyContainer Instance { get; private set; }

        public static AppGlobal GetApp()
        {
            return Instance?.appGlobal;
        }

        public static void InitializeService(Config config)
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer(config);
            }
        }

        public IEnumerable<ElementViewModelBase> GetAllElementsOfCurrentDevicePage()
        {
            return devicePageVm.UnionedElements;
        }

        public InnerRegionPage GetCurrentInnerPage()
        {
            return devicePageVm.CurrentPageKey;
        }

        public void ManageNavigateButtonHintForElement(ElementViewModelBase element, bool hideAll = false)
        {
            if (hideAll)
            {
                devicePageVm.IsGoForwardHintOpen = false;
                devicePageVm.IsGoPreviousHintOpen = false;
                return;
            }

            var currentPageIndex = devicePageVm.Pages.IndexOf(devicePageVm.Pages.Single(p => p.PageKey == GetCurrentInnerPage()));
            var nextPageIndex = devicePageVm.Pages.IndexOf(devicePageVm.Pages.Single(p => p.PageKey == element.Page));

            var direction = currentPageIndex > nextPageIndex
                                ? Direction.Previous
                                : Direction.Forward;

            switch (direction)
            {
                case Direction.Forward:
                    if (!devicePageVm.IsGoForwardHintOpen)
                    {
                        devicePageVm.IsGoForwardHintOpen = true;
                    }

                    break;
                case Direction.Previous:
                    if (!devicePageVm.IsGoPreviousHintOpen)
                    {
                        devicePageVm.IsGoPreviousHintOpen = true;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
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

        public void SetLoadingSplash(bool isLoading)
        {
            mainWindowVm.IsLoadingSplashVisible = isLoading;
        }
    }
}