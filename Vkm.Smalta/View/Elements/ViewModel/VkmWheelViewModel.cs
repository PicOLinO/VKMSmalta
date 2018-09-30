using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmWheelViewModel : ElementViewModelBase
    {
        private bool isMouseButtonPressed;

        private readonly int minValue;
        private readonly int maxValue;

        public ICommand MouseMoveCommand { get; private set; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        protected VkmWheelViewModel(int value, int minValue, int maxValue, string name) : base(value, name)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            
            CreateCommands();
        } 

        private void CreateCommands()
        {
            MouseMoveCommand = new DelegateCommand<MouseWheelEventArgs>(OnMouseWheel);
        }

        private void OnMouseWheel(MouseWheelEventArgs e)
        {
            //TODO:
        }
    }
}