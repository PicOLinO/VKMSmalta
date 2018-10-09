namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmRadarTargetViewModel : ElementViewModelBase
    {
        public VkmRadarTargetViewModel(int value, string name) : base(value, name)
        {
            OpacityPercents = value / 100d;
        }

        public double OpacityPercents
        {
            get { return GetProperty(() => OpacityPercents); }
            set { SetProperty(() => OpacityPercents, value); }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            OpacityPercents = Value / 100d;
        }
    }
}