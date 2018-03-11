using System.Collections.Generic;
using VKMSmalta.Domain;

namespace VKMSmalta.View.Elements.ViewModel
{
    public interface IDependencyActivatorElement
    {
        List<DependencyAction> DependencyActions { get; }
        void NotifyDependedElements();
    }
}