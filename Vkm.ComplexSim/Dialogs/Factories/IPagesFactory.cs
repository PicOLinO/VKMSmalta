#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.InnerPages.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs.Factories
{
    public interface IPagesFactory
    {
        List<MainInnerDevicePageViewModel> CreatePagesFor(Device device, Algorithm algorithm);
    }
}