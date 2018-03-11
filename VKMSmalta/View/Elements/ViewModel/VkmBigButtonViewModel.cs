using System;
using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableElementViewModelBase, IDependencyActivatorElement
    {
        private readonly bool isInitialize;
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public List<DependencyAction> DependencyActions { get; }

        public VkmBigButtonViewModel(int value, string name, HistoryService historyService, string imageOnSource, string imageOffSource, List<DependencyAction> dependencyActions = null) : base(value, name, historyService)
        {
            isInitialize = true;

            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            DependencyActions = dependencyActions;
            Value = value;

            isInitialize = false;
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

        public void NotifyDependedElements()
        {
            foreach(var dependencyAction in DependencyActions)
            {
                dependencyAction.SetDependencyElementValue(Value);
            }
        }
    }
}