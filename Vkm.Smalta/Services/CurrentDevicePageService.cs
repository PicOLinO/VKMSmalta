#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.Services
{
    [Obsolete("Do not use this class. Deprecated", false)]
    public class CurrentDevicePageService
    {
        private readonly DevicePageViewModel devicePageViewModel;

        public CurrentDevicePageService(DevicePageViewModel devicePageViewModel)
        {
            this.devicePageViewModel = devicePageViewModel;
        }

        public static CurrentDevicePageService Instance { get; private set; }

        public static void Initialize(DevicePageViewModel vm)
        {
            Instance = new CurrentDevicePageService(vm);
        }

        public ElementViewModelBase GetElementByName(string name)
        {
            return devicePageViewModel.UnionElements.Single(e => e.Name == name);
        }

        public Enum GetCurrentInnerPageKey()
        {
            return devicePageViewModel.CurrentPageKey;
        }

        public void ShowGoNextPageHint(Enum toPage, bool hideAll = false)
        {
            if (hideAll)
            {
                devicePageViewModel.IsGoForwardHintOpen = false;
                devicePageViewModel.IsGoPreviousHintOpen = false;
                return;
            }

            var currentPageIndex = devicePageViewModel.Pages.IndexOf(devicePageViewModel.Pages.Single(p => Equals(p.PageKey, GetCurrentInnerPageKey())));
            var nextPageIndex = devicePageViewModel.Pages.IndexOf(devicePageViewModel.Pages.Single(p => Equals(p.PageKey, toPage)));

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