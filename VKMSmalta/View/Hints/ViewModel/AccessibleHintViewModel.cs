#region Usings

using VKMSmalta.Services;

#endregion

namespace VKMSmalta.View.Hints.ViewModel
{
    public class AccessibleHintViewModel : HintViewModelBase
    {
        private readonly int accessibleValue;

        public AccessibleHintViewModel(string hintText, int accessibleValue, IHintService hintService) : base(hintText, hintService)
        {
            this.accessibleValue = accessibleValue;
        }

        protected override bool CanOnClickNext()
        {
            var element = HintService.GetValuableElementByCurrentHint();
            return element?.Value == accessibleValue;
        }
    }
}