namespace Vkm.Smalta.View.Elements.ViewModel
{
    public class VkmRadarTargetViewModel : ElementViewModelBase
    {
        protected VkmRadarTargetViewModel(int value, string name) : base(value, name)
        {
        }

        public int OpacityPercent
        {
            get { return GetProperty(() => OpacityPercent / 100); }
            set { SetProperty(() => OpacityPercent, value); }
        }
    }
}