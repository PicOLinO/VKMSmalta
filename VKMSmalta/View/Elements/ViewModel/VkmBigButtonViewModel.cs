using System;
using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel.Interfaces;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableElementViewModelBase, IDependencyActivatorElement
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public List<DependencyAction> DependencyActions { get; }

        public VkmBigButtonViewModel(int value, string name, HistoryService historyService, string imageOnSource, string imageOffSource, List<DependencyAction> dependencyActions = null) : base(value, name, historyService)
        {
            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            DependencyActions = dependencyActions;
            Value = value;
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

            if (DependencyActions != null)
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