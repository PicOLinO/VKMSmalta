using DevExpress.Mvvm;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmRotateWheelViewModel : ElementViewModelBase
    {
        private readonly int rotationStep;
        private readonly int maxRotationSteps;
        private int currentRotationStep;

        public DelegateCommand ClickCommand { get; set; }

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

            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        private void OnClick()
        {
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