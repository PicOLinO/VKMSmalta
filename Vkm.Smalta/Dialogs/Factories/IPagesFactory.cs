using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.InnerPages.ViewModel;

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IPagesFactory
    {
        List<MainInnerDevicePageViewModel> CreatePagesFor(Device device, Algorithm algorithm);
    }
}