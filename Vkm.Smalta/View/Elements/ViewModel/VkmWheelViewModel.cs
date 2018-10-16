using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmWheelViewModel : ElementViewModelBase, IDependencyActivatorElement
    {
        private readonly bool isInitialize;
        private readonly int minValue;
        private readonly int maxValue;
        private readonly int coefficient;

        public ICommand MouseWheelCommand { get; private set; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmWheelViewModel(int value, string imageSource, int minValue, int maxValue, int coefficient, List<DependencyAction> dependencyActions, string name, int posTop, int posLeft, int width, int height, Enum page) : base(value, name, posTop, posLeft, page, width, height)
        {
            isInitialize = true;

            this.minValue = minValue;
            this.maxValue = maxValue;
            this.coefficient = coefficient;
            DependencyActions = dependencyActions;
            ImageSource = imageSource;

            if (Value < minValue)
                Value = minValue;
            if (Value > maxValue)
                Value = maxValue;

            CreateCommands();

            isInitialize = false;
        } 

        private void CreateCommands()
        {
            MouseWheelCommand = new DelegateCommand<MouseWheelEventArgs>(OnMouseWheel);
        }

        private void OnMouseWheel(MouseWheelEventArgs e)
        {
            var delta = e.Delta / 120;
            var nextValue = Value + delta;
            if (nextValue > maxValue || nextValue < minValue)
            {
                return;
            }

            Value = nextValue;
            RotationDegrees = coefficient * Value;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            if (DependencyActions != null && !isInitialize)
            {
                NotifyDependedElements();
            }
        }

        public List<DependencyAction> DependencyActions { get; }

        public void CancelDependencyActionsExecution()
        {
        }

        public void NotifyDependedElements()
        {
            foreach (var dependencyAction in DependencyActions)
            {
                Task.Run(() => dependencyAction.UpdateDependencyElementValue(Value));
            }
        }
    }
}