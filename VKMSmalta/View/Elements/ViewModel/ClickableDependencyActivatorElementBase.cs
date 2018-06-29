#region Usings

using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace VKMSmalta.View.Elements.ViewModel
{
    public abstract class ClickableDependencyActivatorElementBase : ClickableElementViewModelBase, IDependencyActivatorElement
    {
        protected ClickableDependencyActivatorElementBase(int value, string name, HistoryService historyService, List<DependencyAction> dependencyActions) : base(value, name, historyService)
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