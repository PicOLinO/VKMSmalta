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

        public VkmWheelViewModel(int value, string imageSource, int minValue, int maxValue, int coefficient, string name) : base(value, name)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.coefficient = coefficient;
            ImageSource = imageSource;

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