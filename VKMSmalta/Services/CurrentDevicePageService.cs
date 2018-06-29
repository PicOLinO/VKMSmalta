using System;
using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Services
{
    public class CurrentDevicePageService
    {
        private readonly DevicePageViewModel devicePageViewModel;

        public CurrentDevicePageService(DevicePageViewModel devicePageViewModel)
        {
            this.devicePageViewModel = devicePageViewModel;
        }

        public static void Initialize(DevicePageViewModel vm)
        {
            if (Instance == null)
            {
                Instance = new CurrentDevicePageService(vm);
            }
        }

        public static CurrentDevicePageService Instance { get; private set; }

        public IEnumerable<ElementViewModelBase> GetAllElementsOfCurrentDevicePage()
        {
            return devicePageViewModel.UnionedElements;
        }

        public InnerRegionPage GetCurrentInnerPageKey()
        {
            return devicePageViewModel.CurrentPageKey;
        }

        public void ShowGoNextPageHint(InnerRegionPage toPage, bool hideAll = false)
        {
            if (hideAll)
            {
                devicePageViewModel.IsGoForwardHintOpen = false;
                devicePageViewModel.IsGoPreviousHintOpen = false;
                return;
            }

            var currentPageIndex = devicePageViewModel.Pages.IndexOf(devicePageViewModel.Pages.Single(p => p.PageKey == GetCurrentInnerPageKey()));
            var nextPageIndex = devicePageViewModel.Pages.IndexOf(devicePageViewModel.Pages.Single(p => p.PageKey == toPage));

            var direction = currentPageIndex > nextPageIndex
                                ? Direction.Previous
                                : Direction.Forward;

            switch (direction)
            {
                case Direction.Forward:
                    if (!devicePageViewModel.IsGoForwardHintOpen)
                    {
                        devicePageViewModel.IsGoForwardHintOpen = true;
                    }

                    break;
                case Direction.Previous:
                    if (!devicePageViewModel.IsGoPreviousHintOpen)
                    {
                        devicePageViewModel.IsGoPreviousHintOpen = true;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}