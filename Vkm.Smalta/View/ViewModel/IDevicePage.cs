using System;
using Vkm.ComplexSim.View.Elements.ViewModel;

namespace Vkm.ComplexSim.View.ViewModel
{
    public interface IDevicePage
    {
        ElementViewModelBase GetElementByName(string name);
        Enum GetCurrentInnerPageKey();
        void ShowGoNextPageHint(Enum toPage, bool hideAll = false);
    }
}