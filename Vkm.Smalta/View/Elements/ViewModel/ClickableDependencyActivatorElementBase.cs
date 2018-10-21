#region Usings

using System;
using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel.Interfaces;

#endregion

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public abstract class ClickableDependencyActivatorElementBase : ClickableElementViewModelBase, IDependencyActivatorElement
    {
        protected ClickableDependencyActivatorElementBase(int value, string name, List<DependencyAction> dependencyActions, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
            DependencyActions = dependencyActions;
        }

        #region IDependencyActivatorElement

        public void CancelDependencyActionsExecution()
        {
            if (DependencyActions == null || DependencyActions.Count == 0)
            {
                return;
            }

            foreach (var dependencyAction in DependencyActions)
            {
                dependencyAction.CancellationToken = true;
            }
        }

        public virtual void NotifyDependedElements()
        {
        }

        public List<DependencyAction> DependencyActions { get; }

        #endregion
    }
}