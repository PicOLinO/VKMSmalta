#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel.Interfaces
{
    public interface IDependencyActivatorElement
    {
        List<DependencyAction> DependencyActions { get; }
        void NotifyDependedElements();
        void CancelDependencyActionsExecution();
    }
}