namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBlackTriangleArrowViewModel : ElementViewModelBase
    {
        private readonly int startupRotation;

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            RotationDegrees = (11 * Value) + startupRotation;
        }

        public VkmBlackTriangleArrowViewModel(int value, string name, int startupRotation) : base(value, name)
        {
            this.startupRotation = startupRotation;
            Value = value;
        }
    }
}