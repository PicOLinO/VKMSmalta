#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableDependencyActivatorElementBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;
        private readonly bool isInitialize;

        private int dependencyActionsCounter;
        private readonly string dependencySecureElementName;

        public VkmBigButtonViewModel(int value, string name, HistoryService historyService, string imageOnSource, string imageOffSource, List<DependencyAction> dependencyActions = null, string dependencySecureElementName = null) : base(value, name, historyService, dependencyActions)
        {
            isInitialize = true;

            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            this.dependencySecureElementName = dependencySecureElementName;
            Value = value;

            isInitialize = false;
        }

        public bool IsDependencyActionsRunning { get; private set; }

        private void DependencyActionsCounterCallback()
        {
            dependencyActionsCounter++;

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

        #region IDependencyActivatorElement

        public override void NotifyDependedElements()
        {
            if (!string.IsNullOrEmpty(dependencySecureElementName))
            {
                var dependencySecureElement = CurrentDevicePageService.Instance.GetAllElementsOfCurrentDevicePage().Single(e => e.Name == dependencySecureElementName);

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
                Task.Run(() => dependencyAction.UpdateDependencyElementValue(Value, DependencyActionsCounterCallback));
            }
        }

        #endregion
    }
}