#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vkm.ComplexSim.Domain;
using Action = Vkm.ComplexSim.Domain.Action;

#endregion

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public sealed class VkmThumblerViewModel : ClickableDependencyActivatorElementBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;
        private readonly bool isInitialize;

        public VkmThumblerViewModel(int value,
                                    string name,
                                    string imageOffSource,
                                    string imageOnSource,
                                    int startupRotation,
                                    int posTop,
                                    int posLeft,
                                    Enum page,
                                    List<DependencyAction> dependencyActions = null) : base(value, 
                                                                                            name, 
                                                                                            dependencyActions,
                                                                                            posTop,
                                                                                            posLeft,
                                                                                            page)
        {
            isInitialize = true;

            this.imageOffSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            Value = value;
            StartupRotation = startupRotation;

            isInitialize = false;
        }

        public int StartupRotation
        {
            get { return GetProperty(() => StartupRotation); }
            set { SetProperty(() => StartupRotation, value); }
        }

        private void DependencyActionExecutedCallback(string dependencyElementName)
        {
            HistoryService.Actions.Add(new Action(ActionName.Idle, dependencyElementName));
        }

        protected override void Interact()
        {
            base.Interact();

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

        public override void NotifyDependedElements()
        {
            foreach (var dependencyAction in DependencyActions)
            {
                Task.Run(() => dependencyAction.UpdateDependencyElementValueAsync(Value, DependencyActionExecutedCallback));
            }
        }
    }
}