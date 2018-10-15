namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmRadarNoiseViewModel : ElementViewModelBase
    {
        public VkmRadarNoiseViewModel(int value, string name) : base(value, name)
        {
            OpacityPercents = value / 100d;
        }

        public double OpacityPercents
        {
            get { return GetProperty(() => OpacityPercents); }
            set { SetProperty(() => OpacityPercents, value); }
        }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            OpacityPercents = Value / 100d;
        }
    }
}