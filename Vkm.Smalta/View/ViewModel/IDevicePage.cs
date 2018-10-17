using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.ViewModel
{
    public interface IDevicePage
    {
        ElementViewModelBase GetElementByName(string name);
        Enum GetCurrentInnerPageKey();
        void ShowGoNextPageHint(Enum toPage, bool hideAll = false);
    }
}