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
        
        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmRotateWheelViewModel(int startupValue, int startupRotation, int rotationStep, int maxRotationSteps, string image = "/VKMSmalta;component/View/Images/Wheel.png")
        {
            this.rotationStep = rotationStep;
            this.maxRotationSteps = maxRotationSteps;
            this.startupValue = startupValue;
            ImageSource = image;
            RotationDegrees = startupRotation;
            Value = startupValue;
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
                RotationDegrees = 0;
                Value = startupValue;
            }
        }
    }
}