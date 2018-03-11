using VKMSmalta.Services;

namespace VKMSmalta.View.Hints.ViewModel
{
    public class InfluentialHintViewModel : HintViewModelBase
    {
        private readonly int newElementValue;

        public InfluentialHintViewModel(string hintText, HintService hintService, int newElementValue) : base(hintText, hintService)
        {
            this.newElementValue = newElementValue;
        }

        protected override void OnClickNext()
        {
            var element = hintService.GetValuableElementByCurrentHint();
            element.Value = newElementValue;

            base.OnClickNext();
        }
    }
}