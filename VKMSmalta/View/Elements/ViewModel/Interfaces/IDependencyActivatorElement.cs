#region Usings

using System.Collections.Generic;
using VKMSmalta.Domain;

#endregion

namespace VKMSmalta.View.Elements.ViewModel.Interfaces
{
    public interface IDependencyActivatorElement
    {
        List<DependencyAction> DependencyActions { get; }
        void NotifyDependedElements();
        void CancelDependencyActionsExecution();
    }
}