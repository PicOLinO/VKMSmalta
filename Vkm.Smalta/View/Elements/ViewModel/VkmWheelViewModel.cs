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

        protected VkmWheelViewModel(int value, int minValue, int maxValue, int coefficient, string name) : base(value, name)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.coefficient = coefficient;

            CreateCommands();
        } 

        private void CreateCommands()
        {
            MouseWheelCommand = new DelegateCommand<MouseWheelEventArgs>(OnMouseWheel);
        }

        private void OnMouseWheel(MouseWheelEventArgs e)
        {
            var nextValue = Value + e.Delta;
            if (nextValue > maxValue || nextValue < minValue)
            {
                return;
            }

            Value = nextValue;
            RotationDegrees = coefficient * Value;
        }
    }
}