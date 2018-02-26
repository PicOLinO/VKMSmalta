namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBlackTriangleArrowViewModel : ElementViewModelBase, IValuableNamedElement
    {
        private int value;

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public override int Value
        {
            get => value;
            set
            {
                this.value = value;
                RotationDegrees = 10 * value;
            }
        }

        public VkmBlackTriangleArrowViewModel(int value, string name, int startupRotation) : base(value, name)
        {
            RotationDegrees = startupRotation;
        }
    }
}