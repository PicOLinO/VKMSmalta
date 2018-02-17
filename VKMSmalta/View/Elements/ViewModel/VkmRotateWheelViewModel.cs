using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmRotateWheelViewModel : ClickableElementViewModelBase
    {
        private readonly int startupValue;
        private readonly int rotationStep;
        private readonly int maxRotationSteps;
        private readonly int startupRotation;
        
        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmRotateWheelViewModel(int value, string name, int startupRotation, int rotationStep, int maxRotationSteps, string image = "/VKMSmalta;component/View/Images/Wheel.png") : base(value, name)
        {
            this.rotationStep = rotationStep;
            this.maxRotationSteps = maxRotationSteps;
            ImageSource = image;
            RotationDegrees = this.startupRotation = startupRotation;
            startupValue = value;
            Value = value;
        }

        protected override void OnClick()
        {
            base.OnClick();

            if (Value < maxRotationSteps)
            {
                RotationDegrees += rotationStep;
                Value += 1;
            }
            else
            {
                RotationDegrees = startupRotation;
                Value = startupValue;
            }
        }
    }
}