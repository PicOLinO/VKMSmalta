#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.ViewModel;
using Action = Vkm.ComplexSim.Domain.Action;

#endregion

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableDependencyActivatorElementBase
    {
        private readonly string dependencySecureElementName;
        private readonly bool isInitialize;

        private int dependencyActionsCounter;

        public VkmBigButtonViewModel(int value, string name, string imageOnSource, string imageOffSource, int posTop, int posLeft, Enum page, List<DependencyAction> dependencyActions = null, string dependencySecureElementName = null) : base(value, name, dependencyActions, posTop, posLeft, page)
        {
            isInitialize = true;

            ImageOffSource = imageOffSource;
            ImageOnSource = imageOnSource;
            this.dependencySecureElementName = dependencySecureElementName;
            Value = value;
            
            isInitialize = false;
        }

        private bool IsDependencyActionsRunning { get; set; }

        private void DependencyActionsCounterCallback(string dependencyElementName)
        {
            dependencyActionsCounter++;
            HistoryService.Actions.Add(new Action(ActionName.Idle, dependencyElementName));

            if (DependencyActions.Count == dependencyActionsCounter)
            {
                IsDependencyActionsRunning = false;
            }
        }

        public string ImageOnSource
        {
            get { return GetProperty(() => ImageOnSource); }
            set { SetProperty(() => ImageOnSource, value); }
        }

        public string ImageOffSource
        {
            get { return GetProperty(() => ImageOffSource); }
            set { SetProperty(() => ImageOffSource, value); }
        }

        protected override void Interact()
        {
            base.Interact();

            Value = 1;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            if (DependencyActions != null && !isInitialize)
            {
                NotifyDependedElements();
            }
        }

        public override void NotifyDependedElements()
        {
            if (!string.IsNullOrEmpty(dependencySecureElementName))
            {
                var dependencySecureElement = DevicePageViewModel.Instance.GetElementByName(dependencySecureElementName);

                if (dependencySecureElement is VkmBigButtonViewModel button)
                {
                    if (button.IsDependencyActionsRunning)
                    {
                        return;
                    }
                }
            }

            dependencyActionsCounter = 0;
            IsDependencyActionsRunning = true;

            foreach (var dependencyAction in DependencyActions)
            {
                Task.Run(() => dependencyAction.UpdateDependencyElementValueAsync(Value, DependencyActionsCounterCallback));
            }
        }
    }
}