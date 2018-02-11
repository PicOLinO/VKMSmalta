using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmRotateWheelViewModel : ClickableElementViewModelBase
    {
        private readonly int rotationStep;
        private readonly int maxRotationSteps;
        private int currentRotationStep;
        
        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmRotateWheelViewModel(int rotationStep, int maxRotationSteps, string image = "/VKMSmalta;component/View/Images/Wheel.png")
        {
            this.rotationStep = rotationStep;
            this.maxRotationSteps = maxRotationSteps;
            currentRotationStep = 1;
            ImageSource = image;
        }

        protected override void OnClick()
        {
            base.OnClick();

            if (currentRotationStep < maxRotationSteps)
            {
                RotationDegrees += rotationStep;
                currentRotationStep += 1;
            }
            else
            {
                RotationDegrees = 0;
                currentRotationStep = 1;
            }
        }
    }
}