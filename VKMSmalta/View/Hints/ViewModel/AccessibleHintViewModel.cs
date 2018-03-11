using VKMSmalta.Services;

namespace VKMSmalta.View.Hints.ViewModel
{
    public class AccessibleHintViewModel : HintViewModelBase
    {
        private readonly int accessibleValue;

        public AccessibleHintViewModel(string hintText, int accessibleValue, HintService hintService) : base(hintText, hintService)
        {
            this.accessibleValue = accessibleValue;
        }

        protected override bool CanOnClickNext()
        {
            var element = hintService.GetValuableElementByCurrentHint();
            return element?.Value == accessibleValue;
        }
    }
}