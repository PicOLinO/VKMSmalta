#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.View.Elements.ViewModel.Interfaces
{
    public interface IDependencyActivatorElement
    {
        List<DependencyAction> DependencyActions { get; }
        void CancelDependencyActionsExecution();
        void NotifyDependedElements();
    }
}