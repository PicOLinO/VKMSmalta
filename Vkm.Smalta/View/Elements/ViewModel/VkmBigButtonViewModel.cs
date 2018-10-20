#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.ViewModel;
using Action = Vkm.Smalta.Domain.Action;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableDependencyActivatorElementBase
    {
        private readonly string dependencySecureElementName;
        private readonly string imageOffSource;
        private readonly string imageOnSource;
        private readonly bool isInitialize;

        private int dependencyActionsCounter;

        public VkmBigButtonViewModel(int value, string name, string imageOnSource, string imageOffSource, int posTop, int posLeft, Enum page, List<DependencyAction> dependencyActions = null, string dependencySecureElementName = null) : base(value, name, dependencyActions, posTop, posLeft, page)
        {
            isInitialize = true;

            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
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

        protected override void OnMouseLeftButtonDown()
        {
            base.OnMouseLeftButtonDown();

            ImageSource = imageOnSource;
        }

        protected override void OnMouseLeftButtonUp()
        {
            base.OnMouseLeftButtonUp();

            ImageSource = imageOffSource;

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