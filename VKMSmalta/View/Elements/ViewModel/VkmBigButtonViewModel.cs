using System;
using VKMSmalta.Services;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBigButtonViewModel : ClickableElementViewModelBase
    {
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        public VkmBigButtonViewModel(int value, string name, HistoryService historyService, string imageOnSource, string imageOffSource) : base(value, name, historyService)
        {
            this.imageOffSource = ImageSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            Value = value;
        }

        protected override void OnMouseLeftButtonDown()
        {
            base.OnMouseLeftButtonDown();

            ImageSource = imageOnSource;
        }

        protected override void OnMouseLeftButtonUp()
        {
            base.OnMouseLeftButtonUp();

            ImageSource = imageOffSource;
        }
    }
}