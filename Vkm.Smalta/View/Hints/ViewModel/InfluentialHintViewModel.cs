#region Usings

#endregion

namespace Vkm.Smalta.View.Hints.ViewModel
{
    public class InfluentialHintViewModel : HintViewModelBase
    {
        private readonly int newElementValue;

        public InfluentialHintViewModel(string hintText, int newElementValue) : base(hintText)
        {
            this.newElementValue = newElementValue;
        }

        protected override void OnClickNext()
        {
            var element = HintService.GetElementByCurrentHint();
            element.Value = newElementValue;

            base.OnClickNext();
        }
    }
}