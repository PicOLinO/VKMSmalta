using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmWheelViewModel : ElementViewModelBase
    {
        private readonly int minValue;
        private readonly int maxValue;
        private readonly int coefficient;

        public ICommand MouseWheelCommand { get; private set; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmWheelViewModel(int value, string imageSource, int minValue, int maxValue, int coefficient, string name, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.coefficient = coefficient;
            ImageSource = imageSource;

            if (Value < minValue)
                Value = minValue;
            if (Value > maxValue)
                Value = maxValue;

            CreateCommands();
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
    }
}