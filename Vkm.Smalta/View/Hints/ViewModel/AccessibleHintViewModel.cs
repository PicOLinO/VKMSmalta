#region Usings

using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.View.Hints.ViewModel
{
    public class AccessibleHintViewModel : HintViewModelBase
    {
        private readonly int accessibleValue;

        public AccessibleHintViewModel(string hintText, int accessibleValue) : base(hintText)
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