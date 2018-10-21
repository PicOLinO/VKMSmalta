using System;

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmRadarTargetViewModel : ElementViewModelBase
    {
        public VkmRadarTargetViewModel(int value, string name, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
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