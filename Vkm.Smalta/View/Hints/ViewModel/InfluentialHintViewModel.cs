﻿#region Usings

using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.View.Hints.ViewModel
{
    public class InfluentialHintViewModel : HintViewModelBase
    {
        private readonly int newElementValue;

        public InfluentialHintViewModel(string hintText, IHintService hintService, int newElementValue) : base(hintText, hintService)
        {
            this.newElementValue = newElementValue;
        }

        protected override void OnClickNext()
        {
            var element = HintService.GetValuableElementByCurrentHint();
            element.Value = newElementValue;

            base.OnClickNext();
        }
    }
}