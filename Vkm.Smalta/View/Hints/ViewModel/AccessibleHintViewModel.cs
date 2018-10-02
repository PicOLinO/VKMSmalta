#region Usings

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
            var element = HintService.GetElementByCurrentHint();
            return element?.Value == accessibleValue;
        }
    }
}