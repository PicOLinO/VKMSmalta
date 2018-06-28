#region Usings

using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableElementViewModelBase, IDependencyActivatorElement
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;
        private readonly bool isInitialize;

        private int dependencyActionsCounter;
        private readonly string dependencySecureElementName;

        public VkmBigButtonViewModel(int value, string name, HistoryService historyService, string imageOnSource, string imageOffSource, List<DependencyAction> dependencyActions = null, string dependencySecureElementName = null) : base(value, name, historyService)
        {
            isInitialize = true;

            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            this.dependencySecureElementName = dependencySecureElementName;
            DependencyActions = dependencyActions;
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

        public void NotifyDependedElements()
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
                dependencyAction.UpdateDependencyElementValue(Value, DependencyActionsCounterCallback);
            }
        }

        public List<DependencyAction> DependencyActions { get; }

        #endregion
    }
}