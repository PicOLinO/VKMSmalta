#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public sealed class VkmThumblerViewModel : ClickableDependencyActivatorElementBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;
        private readonly bool isInitialize;

        public VkmThumblerViewModel(int value,
                                    string name,
                                    HistoryService historyService,
                                    string imageOffSource,
                                    string imageOnSource,
                                    List<DependencyAction> dependencyActions = null) : base(value, name, historyService, dependencyActions)
        {
            isInitialize = true;

            this.imageOffSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            Value = value;

            isInitialize = false;
        }

        public int StartupRotation
        {
            get { return GetProperty(() => StartupRotation); }
            set { SetProperty(() => StartupRotation, value); }
        }

        protected override void OnMouseLeftButtonUp()
        {
            base.OnMouseLeftButtonUp();

            Value = Value == 0
                        ? 1
                        : 0;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            switch (Value)
            {
                case 0:
                    ImageSource = imageOffSource;
                    break;
                case 1:
                    ImageSource = imageOnSource;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            if (DependencyActions != null && !isInitialize)
            {
                NotifyDependedElements();
            }
        }

        #region IDependencyActivatorElement

        public override void NotifyDependedElements()
        {
            foreach (var dependencyAction in DependencyActions)
            {
                Task.Run(() => dependencyAction.UpdateDependencyElementValue(Value));
            }
        }

        #endregion
    }
}